    public class MyEqualityComparer : IEqualityComparer<KeyValuePair<int,List<string>>>
    {
        public bool Equals(KeyValuePair<int, List<string>> x, KeyValuePair<int, List<string>> y)
        {
            //Let's say we are comparing the keys only.
            return x.Key == y.Key;
        }
    
        public int GetHashCode(KeyValuePair<int, List<string>> obj)
        {
            return obj.Key.GetHashCode();
        }
    }
