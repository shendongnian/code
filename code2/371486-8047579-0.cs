    static void BenchBranch() {
        Stopwatch sw = new Stopwatch();
        const int NMAX = 1000000000;
        bool a = true;
        bool b = false;
        bool c = true;
        sw.Restart();
        int sum = 0;
        for (int i = 0; i < NMAX; i++) {
            if (a)
                if (b)
                    if (c)
                        sum++;
            a = !a;
            b = a ^ b;
            c = b;
        }
        sw.Stop();
        Console.WriteLine("1: {0:F3} ms ({1})", sw.Elapsed.TotalMilliseconds, sum);
        sw.Restart();
        sum = 0;
        for (int i = 0; i < NMAX; i++) {
            if (a && b && c) 
                sum++;
            a = !a;
            b = a ^ b;
            c = b;
        }
        sw.Stop();
        Console.WriteLine("2: {0:F3} ms ({1})", sw.Elapsed.TotalMilliseconds, sum);
        sw.Restart();
        sum = 0;
        for (int i = 0; i < NMAX; i++) {
            sum += (a && b && c) ? 1 : 0;
            a = !a;
            b = a ^ b;
            c = b;
        }
        sw.Stop();
        Console.WriteLine("3: {0:F3} ms ({1})", sw.Elapsed.TotalMilliseconds, sum);
    }
