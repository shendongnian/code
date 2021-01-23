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
    	        re1.Match(input);
            sw.Stop();
            if (pass == 2)
                Debug.WriteLine("Regex uncompiled: " +
                    sw.ElapsedMilliseconds + "ms");
    
            sw = Stopwatch.StartNew();
            for (int index = 0; index < iterations; index++)
    	        re2.Match(input);
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
