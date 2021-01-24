        public class ColumnMap
        {
            private readonly Dictionary<string, string> mappings = new Dictionary<string, string>();
        
            public void Add(string t1, string t2)
            {
                mappings.Add(t1, t2);
            }
        
            public string this[string index]
            {
                get
                {
                    // Check for a custom column map.
                    if (forward.ContainsKey(index))
                        return forward[index];
                    if (reverse.ContainsKey(index))
                        return reverse[index];
        
                    // If no custom mapping exists, return the value passed in.
                    return index;
                }
            }
        }
