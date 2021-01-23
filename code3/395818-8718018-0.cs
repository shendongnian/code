        int entries = 102400;
        var full = new Dictionary<int, ulong>();
        var half = new Dictionary<int, ulong>();
        var both = new Dictionary<int, ulong>();
        for (int i = 0; i < entries * 10; i++)
        {
            full.Add(i, (ulong)(i % 20));
            if (i < entries)
            {
                both.Add(i, (ulong)(i % 20));
                half.Add(i, (ulong)(i % 20));
            }
        }
        const int m = 100;
        Stopwatch s1 = Stopwatch.StartNew();
        for (int i = 0; i < m; i++)
        {
            foreach (var key in both.Keys)
            {
                if (!full.ContainsKey(key))
                {
                    throw new Exception();
                }
            }
        }
        s1.Stop();
        Stopwatch s2 = Stopwatch.StartNew();
        for (int i = 0; i < m; i++)
        {
            foreach (var key in both.Keys)
            {
                if (!half.ContainsKey(key))
                {
                    throw new Exception();
                }
            }
        }
        s2.Stop();
        Console.WriteLine("{0},{1}, difference = {2}", s1.ElapsedMilliseconds, s2.ElapsedMilliseconds, s1.ElapsedMilliseconds - s2.ElapsedMilliseconds);
