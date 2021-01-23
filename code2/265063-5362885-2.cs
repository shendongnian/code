    public sealed class Lookup<TKey, TElement> : ILookup<TKey, TElement>
    {
        private readonly Dictionary<TKey, List<TElement>> map;
        private readonly List<TKey> keys;
    
        public Lookup()
            : this(EqualityComparer<TKey>.Default)
        { }
    
        public Lookup(IEqualityComparer<TKey> comparer)
        {
            map = new Dictionary<TKey, List<TElement>>(comparer);
            keys = new List<TKey>();
        }
    
        public void Add(TKey key, TElement element)
        {
            List<TElement> list;
            if (!map.TryGetValue(key, out list))
            {
                list = new List<TElement>();
                map[key] = list;
                keys.Add(key);
            }
            list.Add(element);
        }
    
        public int Count
        {
            get { return map.Count; }
        }
    
        public IEnumerable<TElement> this[TKey key]
        {
            get
            {
                List<TElement> list;
                if (!map.TryGetValue(key, out list))
                {
                    return Enumerable.Empty<TElement>();
                }
                return list.Select(x => x);
            }
        }
    
        public bool Contains(TKey key)
        {
            return map.ContainsKey(key);
        }
    
        public IEnumerator<IGrouping<TKey, TElement>> GetEnumerator()
        {
            return keys.Select(key => new Grouping<TKey, TElement>(key, map[key]))
                        .GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
    
    public sealed class Grouping<TKey, TElement> : IGrouping<TKey, TElement>
    {
        private readonly TKey key;
        private readonly IEnumerable<TElement> elements;
    
        public Grouping(TKey key, IEnumerable<TElement> elements)
        {
            this.key = key;
            this.elements = elements;
        }
    
        public TKey Key { get { return key; } }
    
        public IEnumerator<TElement> GetEnumerator()
        {
            return elements.GetEnumerator();
        }
    
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
