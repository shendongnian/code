    class CachingList<T>
    {
        private readonly Dictionary<string, T> _list = new Blabla..();
        private readonly Func<string,T> _itemsFactory;
    
        public CachingList(Func<string,T> itemsFactory) {
          _itemsFactory = itemsFactory;
        }
    
        public Texture this[string name]
        {
            get
            {
                T t;
    
                if (!_list.TryGetValue(name, out t))
                {
                    t = _itemsFactory(name);
                    List[name] = t;
                }
    
                return t;
            }
        }
    }
