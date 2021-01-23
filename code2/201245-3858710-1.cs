    static DateTime? Parse(string str, string[] patterns)
    {
        DateTime result;
        if (DateTime.TryParseExact(str, patterns, null, DateTimeStyles.None, out result) )
            return result;
        return null;
    }
    static void Main(string[] args)
    {
        var stringDates = new string[] { "05-Oct-2010", "05-Oct", "05-OCT-2010", "05-OCT" };
        var patterns = new string[] {"dd-MMM-yyyy", "dd-MMM"};
        var dates = from s in stringDates
                    let dt = Parse(s, patterns)
                    where dt.HasValue
                    select dt.Value;
                    
        foreach( var d in dates)
            Console.WriteLine(d.ToShortDateString());
    
        Console.ReadLine();
    }
