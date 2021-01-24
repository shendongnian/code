    public String[] Any()
    {                            
       	IEnumerable<String> lastSixMonths = Enumerable.Range(0, 6).Select(i => DateTime.Now.AddMonths(i - 6)).Select(date => date.ToString("MM/yyyy"));
       	return lastSixMonths.ToArray();
    }
