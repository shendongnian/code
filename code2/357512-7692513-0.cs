    public class FooCollection : IEnumerable<Foo>
    {
        private Dictionary<string, Foo> fooDictionary = new Dictionary<string, Foo>();
    
        public IEnumerator<Foo> GetEnumerator()
        {
            return fooDictionary.Values.GetEnumerator();
        }
    
        public IEnumerator IEnumerable.GetEnumerator()
        {
            //forces use of the non-generic implementation on the Values collection
            return ((IEnumerable)fooDictionary.Values).GetEnumerator();
        }
    
        // Other wrapper methods omitted
    
    }
