       class Program
        {
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
                    listA.Add(i);
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
    
                Console.ReadKey();
            }
        }
