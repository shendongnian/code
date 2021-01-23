    static void Main()
    {
        IDictionary<string, IList<string>> specTimes = new Dictionary<string, IList<string>>();
        IList<string> times = new List<string>();
        times.Add("000.00.00");
        times.Add("000.00.00");
        times.Add("000.00.00");
        string spec = "A101";
        specTimes.Add(spec, times);
        int count = specTimes[spec].Count;
    }
