    public class DoubleDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private Dictionary<TKey, TValue> backingHash = new Dictionary<TKey, TValue>();
        private SortedDictionary<TKey, TValue> backingTree = new SortedDictionary<TKey, TValue>();
    
        // For all the modify methods, do it in both.
        // For all retrieval methods, pick one of the backing dictionaries, and just use that one.
        // For example, contains and get on the Hash, iteration on the Tree.
    }
