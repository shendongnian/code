    class Program
    {
        volatile static List<string> strings;
        static double[] results = new double[25];
        static void Main(string[] args)
        {
            strings = new List<string>();
            Random r = new Random();
            for (int rep = 0; rep < 25; rep++)
            {
                Console.WriteLine("Run " + rep);
                strings.Clear();
                for (int i = 0; i < 1000000; i++)
                {
                    string temp = "";
                    for (int j = 0; j < r.Next(3, 101); j++)
                    {
                        temp += Convert.ToChar(
                            Convert.ToInt32(
                            Math.Floor(26 * r.NextDouble() + 65)));
                    }
                    if (i % 4 == 0)
                    {
                        temp += "abc";
                    }
                    strings.Add(temp);
                }
                OrdinalWorker ow = new OrdinalWorker(strings);
                CharWorker cw = new CharWorker(strings);
                if (rep % 2 == 0)
                {
                    cw.Run();
                    ow.Run();
                }
                else
                {
                    ow.Run();
                    cw.Run();                    
                }
                Thread.Sleep(1000);
                results[rep] = ow.finish.Subtract(cw.finish).Milliseconds;
            }
            double tDiff = 0;
            for (int i = 0; i < 25; i++)
            {
                tDiff += results[i];
            }
            double average = tDiff / 25;
            if (average < 0)
            {
                average = average * -1;
                Console.WriteLine("Char compare faster by {0}ms average", 
                    average.ToString().Substring(0, 4));
            }
            else
            {
                Console.WriteLine("EndsWith faster by {0}ms average", 
                    average.ToString().Substring(0, 4));
            }
        }
    }   
    
    class OrdinalWorker
    {
        List<string> list;
        int count;
        public Thread t;
        public DateTime finish;
        public OrdinalWorker(List<string> l)
        {
            list = l;
        }
        public void Run()
        {
            t = new Thread(() => {
                string suffix = "abc";
                for (int i = 0; i < list.Count; i++)
                {
                    count = (list[i].EndsWith(suffix, StringComparison.Ordinal)) ? 
                        count + 1 : count;
                }
                finish = DateTime.Now;
            });
            t.Start();
        }
    }
    class CharWorker 
    {
        List<string> list;
        int count;
        public Thread t;
        public DateTime finish;
        public CharWorker(List<string> l)
        {
            list = l;
        }
        public void Run()
        {
            t = new Thread(() =>
            {
                string suffix = "abc";
                for (int i = 0; i < list.Count; i++)
                {
                    count = (HasSuffix(list[i], suffix)) ? count + 1 : count;
                }
                finish = DateTime.Now;
            });
            t.Start();
        }
        static bool HasSuffix(string check, string suffix)
        {
            int offset = check.Length - suffix.Length;
            for (int i = 0; i < suffix.Length; i++)
            {
                if (check[offset + i] != suffix[i])
                {
                    return false;
                }
            }
            return true;
        }
    }
