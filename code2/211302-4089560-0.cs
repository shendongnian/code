    using System;
    using System.Diagnostics;
    
    class With
    {
        int x;
        
        public With()
        {
            x = 0;
        }
    }
    
    
    class Without
    {
        int x;
        
        public Without()
        {
        }
    }
    
    
    class Test
    {
        static void Main(string[] args)
        {
            int iterations = int.Parse(args[0]);
            Stopwatch sw = Stopwatch.StartNew();
            if (args[1] == "with")
            {
                for (int i = 0; i < iterations; i++)
                {
                    new With();
                }
            }
            else
            {
                for (int i = 0; i < iterations; i++)
                {
                    new Without();
                }
            }
            sw.Stop();
            Console.WriteLine(sw.ElapsedMilliseconds);
        }
    }
