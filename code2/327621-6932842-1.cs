    public class CollectionInitAttribute : Attribute, IEnumerable<string>
    {
        public void Add(string s1, string s2)
        {
            
        }
        public IEnumerator<string> GetEnumerator()
        {
            throw new NotImplementedException();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
