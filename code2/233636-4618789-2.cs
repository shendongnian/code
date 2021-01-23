    public static void Main()
    {
        for (int run = 0; run < 4; ++run)
        {
            if (run != 0)
            {
                // Ignore first run
                Console.WriteLine("Run {0}", run);
            }
            var al = new List<object>();
            var l = new List<p1>();
            var sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                al.Add(new p1(i));
            }
            p1 b;
            for (int i = 0; i < 1000; i++)
            {
                b = (p1)al[i];
            }
            sw.Stop();
            if (run != 0)
            {
                // Ignore first run
                Console.WriteLine("With boxing: {0}", sw.ElapsedTicks);
            }
            sw.Reset();
            sw.Start();
            for (int i = 0; i < 1000; i++)
            {
                l.Add(new p1(i));
            }
            p1 v;
            for (int i = 0; i < 1000; i++)
            {
                v = l[i];
            }
            sw.Stop();
            if (run != 0)
            {
                // Ignore first run
                Console.WriteLine("Without boxing: {0}", sw.ElapsedTicks);
            }
        }
        Console.ReadKey();
    }
