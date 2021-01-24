public class MultipleBy2Test
{
    private readonly Dictionary<int, int> _values = new Dictionary<int, int>();
    public void AddItem(int originalAmount)
    {
        _values.Add(originalAmount, originalAmount * 2);
    }
}
Now the class doesn't inherit from `Dictionary<int, int>` and nothing in its public interface allows access to the dictionary. Data integrity is ensured because nothing but your method can add anything to the dictionary.
Ideally you would just add a few methods to retrieve values and be done, if that were an option.
If you want *all* of the other methods of a dictionary then you would implement `IDictionary<int, int>`. Because of what a nuisance this is, I'd start with a generic implementation and make the `Add` methods virtual. That way if you want another dictionary with different logic you don't have to create another class and implement all this stuff again.
    public class MyDictionary<TKey, TValue> : IDictionary<TKey, TValue>
    {
        private readonly IDictionary<TKey, TValue> _innerDictionary 
            = new Dictionary<TKey, TValue>();
        public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
        {
            return _innerDictionary.GetEnumerator();
        }
        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
        public virtual void Add(KeyValuePair<TKey, TValue> item)
        {
            _innerDictionary.Add(item);
        }
        public void Clear()
        {
            _innerDictionary.Clear();
        }
        
        public bool Contains(KeyValuePair<TKey, TValue> item)
        {
            return _innerDictionary.Contains(item);
        }
        public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
        {
            _innerDictionary.CopyTo(array, arrayIndex);
        }
        public bool Remove(KeyValuePair<TKey, TValue> item)
        {
            return _innerDictionary.Remove(item);
        }
        public int Count => _innerDictionary.Count;
        public bool IsReadOnly => _innerDictionary.IsReadOnly;
        public bool ContainsKey(TKey key)
        {
            return _innerDictionary.ContainsKey(key);
        }
        public virtual void Add(TKey key, TValue value)
        {
            _innerDictionary.Add(key, value);
        }
        public bool Remove(TKey key)
        {
            return _innerDictionary.Remove(key);
        }
        public bool TryGetValue(TKey key, out TValue value)
        {
            return _innerDictionary.TryGetValue(key, out value);
        }
        public TValue this[TKey key]
        {
            get => _innerDictionary[key];
            set => _innerDictionary[key] = value;
        }
        public ICollection<TKey> Keys => _innerDictionary.Keys;
        public ICollection<TValue> Values => _innerDictionary.Values;
    }
That gets you a dictionary implementation where you can override the `Add` methods. You can reject values that doesn't meet your requirements. You could create other overloads for `Add` if you want to.
    public class MyInheritedDictionary : MyDictionary<int, int>
    {
        public override void Add(KeyValuePair<int, int> item)
        {
            Add(item.Key, item.Value);
        }
        public override void Add(int key, int value)
        {
            if (value != key * 2)
                throw new ArgumentException("You've violated some rule.");
            base.Add(key, value);
        }
    }
