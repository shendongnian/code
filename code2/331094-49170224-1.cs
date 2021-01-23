    static void Main(string[] args)
    {
        var dtOrig = new DateTime(2018, 03, 1, 10, 10, 10);
        var dtNew = dtOrig.AddMilliseconds(100);
        //// perf run for not-equal dates comparison
        //dtNew = dtNew.AddDays(1);
        //dtNew = dtNew.AddMinutes(1);
        int N = 1000000;
        bool isEqual = false;
        var sw = Stopwatch.StartNew();
        for (int i = 0; i < N; i++)
        {
            // TrimMilliseconds comes from 
            // https://stackoverflow.com/a/7029046/1506454 
            // answer by Dean Chalk
            isEqual = dtOrig.TrimMilliseconds() == dtNew.TrimMilliseconds();
        }
        var ms = sw.ElapsedMilliseconds;
        Console.WriteLine("DateTime trim: " + ms + " ms");
        sw = Stopwatch.StartNew();
        for (int i = 0; i < N; i++)
        {
            isEqual = dtOrig.CompareWith(dtNew);
        }
        ms = sw.ElapsedMilliseconds;
        Console.WriteLine("DateTime partial compare: " + ms + " ms");
        Console.ReadKey();
    }
