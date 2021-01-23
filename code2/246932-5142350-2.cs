    void Main()
    {
        string input = "abcdefghijklmnopq";
        string first = "de";
        string last = "op";
        Regex re1 = new Regex("de(.*)op", RegexOptions.None);
        Regex re2 = new Regex("de(.*)op", RegexOptions.Compiled);
        
        // pass 1 is JIT preheat
        for (int pass = 1; pass <= 2; pass++)
        {
            int iterations = 1000000;
            if (pass == 1)
                iterations = 1;
                
            Stopwatch sw = Stopwatch.StartNew();
            for (int index = 0; index < iterations; index++)
    	        BetweenOfFixed(input, first, last);
            sw.Stop();
            if (pass == 2)
                Debug.WriteLine("IndexOf: " + 
                    sw.ElapsedMilliseconds + "ms");
    
            sw = Stopwatch.StartNew();
            for (int index = 0; index < iterations; index++)
    	        BetweenOfRegexAdhoc(input, first, last);
            sw.Stop();
            if (pass == 2)
                Debug.WriteLine("Regex adhoc: " + 
                    sw.ElapsedMilliseconds + "ms");
    
            sw = Stopwatch.StartNew();
            for (int index = 0; index < iterations; index++)
    	        BetweenOfRegexCached(input, first, last);
            sw.Stop();
            if (pass == 2)
                Debug.WriteLine("Regex uncompiled: " +
                    sw.ElapsedMilliseconds + "ms");
    
            sw = Stopwatch.StartNew();
            for (int index = 0; index < iterations; index++)
    	        BetweenOfRegexCompiled(input, first, last);
            sw.Stop();
            if (pass == 2)
                Debug.WriteLine("Regex compiled: " +
                    sw.ElapsedMilliseconds + "ms");
        }
    }
    
    public static string BetweenOfFixed(string ActualStr, string StrFirst,
        string StrLast)
    {
        int startIndex = ActualStr.IndexOf(StrFirst) + StrFirst.Length;
        int endIndex = ActualStr.IndexOf(StrLast, startIndex);
        return ActualStr.Substring(startIndex, endIndex - startIndex);
    }
    
    public static string BetweenOfRegexAdhoc(string ActualStr, string StrFirst,
        string StrLast)
    {
        // I'm assuming you don't replace the delimiters on every call
        Regex re = new Regex("de(.*)op", RegexOptions.None);
        return re.Match(ActualStr).Groups[1].Value;
    }
    
    private static Regex _BetweenOfRegexCached =
        new Regex("de(.*)op", RegexOptions.None);
    public static string BetweenOfRegexCached(string ActualStr, string StrFirst,
        string StrLast)
    {
        return _BetweenOfRegexCached.Match(ActualStr).Groups[1].Value;
    }
    
    private static Regex _BetweenOfRegexCompiled =
        new Regex("de(.*)op", RegexOptions.Compiled);
    public static string BetweenOfRegexCompiled(string ActualStr, string StrFirst,
        string StrLast)
    {
        return _BetweenOfRegexCompiled.Match(ActualStr).Groups[1].Value;
    }
