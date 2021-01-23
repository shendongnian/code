    using(StreamWriter w = new StreamWriter(outFile))
    {
        foreach(string x in xs)
        if(Checker.check(x, speller))
        {
            w.WriteLine("[{0}]", x);
            Console.WriteLine("[{0}]", x);
        }
    }
