    public static void Main()
            {
                int tRuns = 1000000;
                List<String> tList = new List<string>();
                for (int i = 0; i < tRuns; i++) tList.Add(i.ToString());
                Stopwatch s = new Stopwatch();
                s.Start();
                int tSum = 0;
                for (int i = tRuns - 1; i >= 0; i--) 
                {
                    tSum += Convert.ToInt32(tList[i]);
                }
                s.Stop();
                Console.WriteLine("convert: " + s.ElapsedMilliseconds);
    
                Console.WriteLine("tSum:" + tSum); 
    
                s.Reset();
                s.Start();
                tSum = 0; 
                for (int i = tRuns - 1; i >= 0; i--) 
                { 
                    tSum += Int32.Parse(tList[i]); 
                } 
                s.Stop();
                Console.WriteLine("parse: " + s.ElapsedMilliseconds);
                Console.WriteLine("tSum:" + tSum);
                Console.ReadKey();
            }
