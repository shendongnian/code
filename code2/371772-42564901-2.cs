    static void Main(string[] args)
    {
        var a = string.Intern(ReadFromDb());
        var b = string.Intern(ReadFromDb());
        //var a = ReadFromDb();
        //var b = ReadFromDb();
        int equals = 0;
        var stopwatch = Stopwatch.StartNew();
        for (int i = 0; i < 250 * 1000 * 1000; i++)
        {
            if (a == b) equals++;
        }
        stopwatch.Stop();
        Console.WriteLine(stopwatch.Elapsed + ", equals: " + equals);
    }
