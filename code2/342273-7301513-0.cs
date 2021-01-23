    public class OrdinalStringComparer : IEqualityComparer<string>
    {
        public bool Equals(string s1, string s2)
        {
            return string.Equals(s1, s2, StringComparison.OrdinalCultureIgnoreCase);
        }
        public int GetHashCode(string str)
        {
            return (str == null) ? 0 : str.GetHashCode();
        }
    }
