    public interface ICacheWithCumulativeSize
    {
      void Add(string key, string value);
      bool Contains(string key);
      void Remove(string key);
      int CumulativeSize { get; }
    }
    
    public class MyCache : ICacheWithCumulativeSize
    {
      private IDictionary<string, string> dict = new Dictionary<string, string>();
    
      public void Add(string key, string value)
      {
        CumulativeSize += value.Length;
        dict[key] = value;
      }
    
      public bool Contains(string key)
      {
        return dict.ContainsKey(key);
      }
    
      public void Remove(string key)
      {
        string toRemove = dict[key];
        CumulativeSize -= value.Length;
        dict.Remove(key);
      }
      
      int CumulativeSize { public get; private set; }
    }
