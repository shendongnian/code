    public static int GetNumberFromStr(string str)
    {
        str = str.Trim();
        Match m = Regex.Match(str, @"^.*of\s(?<TripCount>\d+)");
    
        return m.Groups["TripCount"].Length > 0 ? int.Parse(m.Groups["TripCount"].Value) : 0;
    }
