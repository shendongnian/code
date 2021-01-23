    string test = "University of California, 1980-85";
    System.Diagnostics.Stopwatch watch = new System.Diagnostics.Stopwatch();
    long totalTicks1 = 0;
    long totalTicks2 = 0;
    char[] testChars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' };
    Regex re = new Regex(@"\d+");
    for (int i = 0; i < 1000; i++)
    {
        watch.Reset();
        watch.Start();
        Match m = re.Match(test);
        watch.Stop();
        totalTicks1 += watch.ElapsedTicks;
        watch.Reset();
        watch.Start();
        int index = test.IndexOfAny(testChars);
        watch.Stop();
        totalTicks2 += watch.ElapsedTicks;
    }
