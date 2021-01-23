    static void Main(string[] args)
    {
        DateTime begin = DateTime.Now;
        DateTime end = begin.AddYears(1).AddMonths(1);
        var result = end.Subtract(begin).TotalDays;
    }
