    // inherit from IEnumerable<whatever>
    public class Cat : IEnumerable<KeyValuePair<string,string>>
    {
        private Dictionary<string, string> catNameAndType = new Dictionary<string, string>();
    
        public Cat()
        {
    
        }
    
        // have your Add() method(s)
        public void Add(string catName, string catType)
        {
            catNameAndType.Add(catName, catType);
        }
    
        // generally just return an enumerator to your collection
        public IEnumerator<KeyValuePair<string, string>> GetEnumerator()
        {
            return catNameAndType.GetEnumerator();
        }
    
        // the non-generic form just calls the generic form
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
