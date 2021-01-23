    public delegate void CollectionAlteredEventHander( object sender , EventArgs e);
    
    public partial class ObservableDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        /*Class contructors*/
        public event CollectionAlteredEventHander CollectionAltered;
        public new TValue this[TKey key]
        {
            get
            {
                return base[key];
            }
            set
            {
                OnCollectionAltered(new EventArgs());
                base[key] = value;
            }
        }
        public new void Add(TKey key, TValue value)
        {
            int idx = 0;
            if (!TryGetKeyIndex(this, key, ref idx))
            {
                base.Add(key, value);
                OnCollectionAltered(new EventArgs());
            }
        }
        public new bool Remove(TKey key)
        {
            int idx = 0; 
            if( TryGetKeyIndex( this ,key, ref idx))
            {
                OnCollectionAltered(new EventArgs());
                return base.Remove(key);
            }
            return false;
        }
        private bool TryGetKeyIndex(ObservableDictionary<TKey, TValue> observableDictionary, TKey key , ref int idx)
        {
            foreach (KeyValuePair<TKey, TValue> pair in observableDictionary) 
            {
                if (pair.Key.Equals(key)) 
                {
                    return true;
                }
                idx++;
            }
            return false;
        }
        public new void Clear()
        {
            OnCollectionAltered(new EventArgs());
            base.Clear();            
        }
        
        protected virtual void OnCollectionAltered(EventArgs e)
        {
            if (CollectionAltered != null)
            {
                CollectionAltered(this, e);
            }
        }
    }
