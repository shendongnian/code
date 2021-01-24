    public class HashKey<T> : IEquatable<HashKey<T>>
    {
        private HashSet<T> _items;
        public HashSet<T> Items
        {
            get {return _items;}
            private set {_items = value;}
        }
        public HashKey()
        {
            _items = new HashSet<T>();
        }
        public HashKey(HashSet<T> initialSet)
        {
            _items = initialSet ?? new HashSet();
        }
        public override int GetHashCode()
        {
            // I'm leaving this for you to do
        }
        public override bool Equals(Object obj)
        {
            if (! (obj is HashKey)) return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }
        public bool Equals(HashSet<T> obj)
        {
            if (obj is null) return false;
            return this.GetHashCode().Equals(obj.GetHashCode());
        }
    }      
   
   
