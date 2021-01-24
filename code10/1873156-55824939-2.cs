    public String[] Any()
    {                            
        IEnumerable<string> lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6).ToString("MM/yyyy"));
        // Now we convert it into an array.
        string[] returned = lastSixMonths.ToArray();
        return returned;
    }
