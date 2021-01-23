    var s1 = "HeLLo    wOrld!";
    var s2 = "Hello\n    WORLd!";
    var watch = Stopwatch.StartNew();
    for (var i = 0; i < 1000000; i++)
    {
        Equals_Linq(s1, s2);
    }
    Console.WriteLine(watch.Elapsed); // ~1.7 seconds
    watch = Stopwatch.StartNew();
    for (var i = 0; i < 1000000; i++)
    {
        Equals_Regex(s1, s2);
    }
    Console.WriteLine(watch.Elapsed); // ~4.6 seconds
