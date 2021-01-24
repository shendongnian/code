     private const string DashPattern = @"[\u2012\u2013\u2014\u2015]";
     private static Regex _dashRegex = new Regex(DashPattern);
     public static string RemoveLongDashes(string s)
     {
         return _dashRegex.Replace(s, "-");
     }
