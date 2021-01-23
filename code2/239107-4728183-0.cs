    public class CustomComparer : IComparer<string>
    {
        public int Compare(string x, string y)
        {
            // do your own comparison however you like; return a negative value
            // to indicate that x < y, a positive value to indicate that x > y,
            // or 0 to indicate that they are equal.
        }
    }
    
    ...
    
    SortedDictionary<string, object> dict = 
                  new SortedDictionary<string, object>(new CustomComparer());
