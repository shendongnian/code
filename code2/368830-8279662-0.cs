    public class UnitOfWork : IDisposable {
        [ThreadStatic]
        public static UnitOfWork Current { get; set; }
        private IDictionary<string, object> _items;
        public IDictionary<string, object> Items 
        {
             get { 
                  if(_items == null) 
                  {
                     _items = new Dictionary<string, object>();
                  }
                  return _items;
             }
        }
        public void Dispose()
        {
             Current = null;
        }
        public static UnitOfWork Start() 
        {
             Current = new UnitOfWork();
             return Current;
        }
    }
