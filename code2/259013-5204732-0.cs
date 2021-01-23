    public static class StringExtensions
    {
    
        public static string RemoveOccurences(this string s, string occurence)
        {
    
             return s.Replace(occurence, "");    
        }
    
    }
