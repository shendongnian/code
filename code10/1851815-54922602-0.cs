     public class ApplicationCacheManager
            {
                private Dictionary<string, object> Data { get; set; }
        
                public ApplicationCacheManager()
                {
                    Data = new Dictionary<string, object>();
                }
        
                public bool IsSet(string key)
                {
                    return Data.TryGetValue(key, out var data) && data != null;
                }
        
                public T Get<T>(string key)
                {
                    if (Data.TryGetValue(key, out var data))
                        return (T)data;
        
                    return default(T);
                }
        
                public void Set<T>(string key, T data)
                {
                    Data[key] = data;
                }
        
                public void Remove(string key)
                {
                    Data.Remove(key);
                }
        
                public void Dispose()
                {
                    if (Data != null)
                        Data = null;
                }
            }
