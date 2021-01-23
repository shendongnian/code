    void Main()
    {
        string s = "This is a test, with multiple characters";
        var statistics =
            from c in s
            group c by c into g
            select new { g.Key, count = g.Count() };
        var mostFrequestFirst =
            from entry in statistics
            orderby entry.count descending
            select entry;
        foreach (var entry in mostFrequestFirst)
        {
            Debug.WriteLine("{0}: {1}", entry.Key, entry.count);
        }
    }
