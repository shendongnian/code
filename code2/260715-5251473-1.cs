       static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            Console.WriteLine("Adding a million 32bit integers");
            sw.Start();
            List<int> listA = new List<int>();
            for(int i = 0; i < 1000000; i++)
            {
                listA.Add(i);
            }
            sw.Stop();
            Console.WriteLine("List<int> took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            List<object> listB = new List<object>();
            for (int i = 0; i < 1000000; i++)
            {
                listB.Add(i);
            }
            sw.Stop();
            Console.WriteLine("List<object> took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            ArrayList listC = new ArrayList();
            for(int i = 0; i < 1000000; i++)
            {
                listC.Add(i);
            }
            sw.Stop();
            Console.WriteLine("ArrayList took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.WriteLine("\n Inserting 1000 values");
            //Gen list of random numbers
            Random rand = new Random(12345);
            int[] insertlocs = new int[1000];
            for (int i = 0; i < insertlocs.Length; i++)
                insertlocs[i] = rand.Next(1, 999999);
            sw.Start();
            for (int i = 0; i < insertlocs.Length; i++)
            {
                listA.Insert(insertlocs[i], i);
            }
            sw.Stop();
            Console.WriteLine("List<int> took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < insertlocs.Length; i++)
            {
                listB.Insert(insertlocs[i], i);
            }
            sw.Stop();
            Console.WriteLine("List<object> took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int i = 0; i < insertlocs.Length; i++)
            {
                listC.Insert(insertlocs[i], i);
            }
            sw.Stop();
            Console.WriteLine("ArrayList took {0} ms", sw.ElapsedMilliseconds);
            sw.Reset();
            Console.ReadKey();
        }
