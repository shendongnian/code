    public class CustomComparer : IComparer<string>
    {
        public int Compare(string  x, string y)
        {
            string s1 = (string) x;
            string s2 = (string) y;
    
            return DateTime.Compare(DateTime.ParseExact(s1.Substring(1), "MMddyyyy", CultureInfo.InvariantCulture), 
                                    DateTime.ParseExact(s2.Substring(1), "MMddyyyy", CultureInfo.InvariantCulture));
        }
    }
