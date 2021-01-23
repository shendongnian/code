            class CrossHairsCollection : List<CrossHairs>
            {
                
            }
    
            class CrossHairs
            {
                private Dictionary<string, object> dict = new Dictionary<string,object>();
    
                public IEnumerable<KeyValuePair<string, object>> GetAllProperties()
                {
                    foreach (string key in dict.Keys)
                    {
                        yield return new KeyValuePair<string, object>(key, dict[key]);
                    }
                }
    
                public object GetProperty(string s)
                {
                    object value;
    
                    bool exists = dict.TryGetValue(s, out value);
                    if (!exists)
                    {
                        value = null;
                    }
    
                    return value;
                }
    
                public void SetProperty(string s, object o)
                {
                    if (!dict.ContainsKey(s))
                    {
                        dict.Add(s, o);
                    }
                    else
                    {
                        dict[s] = o;
                    }
                }
            }
