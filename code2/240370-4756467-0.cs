        static void Main(string[] args)
        {
            string s = "104563";
            int a = 1;
            for (int k = 0; k < 4; k++)
            {
                Stopwatch w = Stopwatch.StartNew();
                for (int i = 0; i < 10000000; i++)
                    a = (int)Convert.ChangeType(s, typeof(int));
                w.Stop();
                Console.WriteLine("ChangeType={0}", w.ElapsedMilliseconds);
                Stopwatch w1 = Stopwatch.StartNew();
                for (int i = 0; i < 10000000; i++)
                    a = Convert.ToInt32(s);
                w1.Stop();
                Console.WriteLine("ToInt32={0}", w1.ElapsedMilliseconds);
                Stopwatch w2 = Stopwatch.StartNew();
                for (int i = 0; i < 10000000; i++)
                    a = Int32.Parse(s);
                w2.Stop();
                Console.WriteLine("Parse={0}", w2.ElapsedMilliseconds);
            }
            Console.ReadLine();
        }
