    class Program
    {
        static void Main(string[] args)
        {
            List<string> lst1 = new List<string>();
            List<string> lst2 = new List<string>();
            CaseInsensitiveEquityComparer comparer = new CaseInsensitiveEquityComparer();
            var result = lst1.Intersect(lst2, comparer);
        }
    }
    class CaseInsensitiveEquityComparer : IEqualityComparer<string>
    {
        public bool Equals(string x, string y)
        {
            return String.Compare(x,y,true,CultureInfo.CurrentCulture) == 0;
        }
        public int GetHashCode(string obj)
        {
            return obj.GetHashCode();
        }
    }
