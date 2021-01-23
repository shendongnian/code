    public class QueryCache
    {
        public class DataObject
        { 
           public bool Data1 { get; set; }
           public string Data2 { get; set; }
           public int Data3 { get; set; }
        }
        Dictionary<string, DataObject> _cache = new Dictionary<string, DataObject>();    
    
        public void AddToCache(DataObject obj_)
        {
            _cache.Add(obj_.Data2, obj_);
        }
        public bool ExistsInCache(string searchTerm_)
        {
            return _cache.ContainsKey(searchTerm_);
        }
        public DataObject this[string searchTerm_]
        {
            get
            {
                 return _cache[searchTerm_];
            }
        }
    }
