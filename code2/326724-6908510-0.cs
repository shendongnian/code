       public class Items : IEnumerable<Configuration>
        {
            private Dictionary<string, Configuration> _items = new Dictionary<string, Configuration>();
    
    
            public void Add(string element, Configuration config) {
                _items[element] = config;
            }
    
            public Configuration this[string element]
            {
                get
                {
    
                    if (_items.ContainsKey(element))
                    {
                        return _items[element];
                    }
                    else
                    {
                        return null;
                    }
                }
    
                set
                {
                    _items[element] = value;
                }
            }
    
            public IEnumerator<Configuration> GetEnumerator()
            {
                return _items.Values.GetEnumerator();
            }
    
            System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
            {
                return _items.Values.GetEnumerator();
            }
        }
