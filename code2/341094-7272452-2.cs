    public class MainCollection<TKey1, TKey2, TValue>
    {
        Tuple<TKey1, TKey2> key;
        Dictionary<TKey1, Tuple<TKey1, TKey2>> k1Dictionary = new Dictionary<TKey1, Tuple<TKey1, TKey2>>();
        Dictionary<TKey2, Tuple<TKey1, TKey2>> k2Dictionary = new Dictionary<TKey2, Tuple<TKey1, TKey2>>();
        Dictionary<Tuple<TKey1, TKey2>, TValue> mainCollection = new Dictionary<Tuple<TKey1, TKey2>, TValue>();
    
        public void Add(Tuple<TKey1, TKey2> Key, TValue Value)
        {
            mainCollection.Add(Key, Value);
    
            k1Dictionary.Add(Key.Item1, Key);
            k2Dictionary.Add(Key.Item2, Key);
        }
    
        public TValue GetValue(TKey1 Key)
        {
            return mainCollection[k1Dictionary[Key]];
        }
    
        public TValue GetValue(TKey2 Key)
        {
            return mainCollection[k2Dictionary[Key]];
        }
    }
