    using System;
    using System.Diagnostics;
    class Program
    {
    static void Main(string[] args)
    {
        int w = 1000;
        int h = 1000;
        int c = 1000;
        TestL(w, h);
        TestM(w, h);
        var swl = Stopwatch.StartNew();
        for (int i = 0; i < c; i++)
        {
            TestL(w, h);
        }
        swl.Stop();
        var swm = Stopwatch.StartNew();
        for (int i = 0; i < c; i++)
        {
            TestM(w, h);
        }
        swm.Stop();
        Console.WriteLine(swl.Elapsed);
        Console.WriteLine(swm.Elapsed);
        Console.ReadLine();
    }
    static void TestL(int w, int h)
    {
        byte[] b = new byte[w * h];
        int q = 0;
        for (int x = 0; x < w; x++)
            for (int y = 0; y < h; y++)
                b[q++] = 1;
    }
    static void TestM(int w, int h)
    {
        byte[,] b = new byte[w, h];
        
        for (int y = 0; y < h; y++)
            for (int x = 0; x < w; x++)
                b[y, x] = 1;
    }
    }
