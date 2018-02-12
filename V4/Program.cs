using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Diagnostics;

namespace V4
{
    class Program
    {
        static void Main(string[] args)
        {
            int choice = Convert.ToInt32(Console.ReadLine());
            switch (choice)
            {
                case 1:
                    DataAnalys test = new DataAnalys();
                    test.Execute("G://ALL//УЧЕБА//ZHOLOBOVA//ОС-САОД//V4//PR2.csv",
                                    "G://ALL//УЧЕБА//ZHOLOBOVA//ОС-САОД//V4//resultV.txt",
                                        "G://ALL//УЧЕБА//ZHOLOBOVA//ОС-САОД//V4//resultP.txt");
                    break;
            }
            Console.ReadKey(true);
        }
    }

    class Building
    {
        private int V, DAV, OBL;

        public Building(int V, int DAV, int OBL)
        {
            this.V = V;
            this.DAV = DAV;
            this.OBL = OBL;
        }

         public Building(Building b)
        {
            this.V = b.V;
            this.DAV = b.DAV;
            this.OBL = b.OBL;
         }
        public int getV() { return this.V; }
        public int getDAV() { return this.DAV; }
        public int getOBL() { return this.OBL; }
         
    }

    class DataAnalys
    {
        public bool Execute(string file1, string file2, string file3)
        {
            if (!File.Exists(file1))
                return false;
            int count = File.ReadAllLines(file1).Length;
            Building[] builds = new Building[count];
            Building[] builds1 = new Building[count];
            Stopwatch SW = new Stopwatch();
            Stopwatch SW1 = new Stopwatch();
            char delimeter = ',';
            try
            {
                using (StreamReader reader = new StreamReader(file1, Encoding.GetEncoding(1251)))
                {
                    for (int i = 0; i < count; i++)
                    {
                        string text = reader.ReadLine();
                        string[] subtext = text.Split(delimeter);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            SW.Start(); builds = Sort(builds);
            SW.Stop(); SW1.Start();
            builds1 = Sort1(builds1); SW1.Stop();
            return true;
        }
        public Building[] Sort(Building[] builds)
        {
            Building b;
            int i, j, max, nmax;
            for (i = 0; i < builds.Length - 1; i++)
            {
                max = builds[i].getV();
                nmax = i;
                for (j = i + 1; j < builds.Length; j++)
                {
                    if (builds[j].getV() < max)
                    {
                        max = builds[j].getV();
                        nmax = j;
                    }
                }
                b = builds[nmax];
                builds[nmax] = builds[i];
                builds[i] = b;
            }
            return builds;
        }
        public Building[] Sort1(Building[] builds1)
        {
            int i, k = 10000000, n = 10000000;
            int[] cr = new int[k + 1];
            n = builds1.Length;
            Building[] br = new Building[n];
            for (i = 0; i <= k; i++)
                cr[i] = 0;
            for (i = 0; i < n; i++)
                cr[builds1[i].getV()] += 1;
            for (i = 1; i <= k + 1; i++)
                cr[i] += cr[i - 1];
            for (i = n - 1; i >= 0; i--)
            {
                br[cr[builds1[i].getV()] - 1] = builds1[i];
                cr[builds1[i].getV()] -= 1;
            }
            return br;
        }
        public void Print(string file, Building[] builds)
        {
            using (StreamWriter writer = File.CreateText(file))
            {
                for (int i = 0; i < builds.Length; i++)
                {
                    writer.WriteLine("{0}, {1}, {2}", builds[i].getV(), builds[i].getDAV(), builds[i].getOBL());
                }
            }
        }
    }
}
 