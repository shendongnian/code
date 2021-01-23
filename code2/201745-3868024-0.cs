    class Program
    {
        struct TwoFloats
        {
            public float x;
            public float y;
        }
        static TwoFloats[] a = new TwoFloats[10000];
        static int Test1a()
        {
            int count = 0;
            for (int i = 0; i < 10000; i += 1)
            {
                if (a[i].x < a[i].y) count++;
            }
            return count;
        }
        static int Test1b()
        {
            int count = 0;
            foreach (TwoFloats t in a)
            {
                if (t.x < t.y) count++;
            }
            return count;
        }
        static void Main(string[] args)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int j = 0; j < 5000; ++j)
            {
                Test1a();
            }
            sw.Stop();
            Trace.WriteLine(sw.ElapsedMilliseconds);
            sw.Reset();
            sw.Start();
            for (int j = 0; j < 5000; ++j)
            {
                Test1b();
            }
            sw.Stop();
            Trace.WriteLine(sw.ElapsedMilliseconds);
        }
    }
