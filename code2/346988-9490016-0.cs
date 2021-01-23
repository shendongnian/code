	public class DictionaryWrapper<TKey, TValue> : IDictionary<TKey, TValue>
	{
		IDictionary<TKey, TValue> innerDictionary;
		public DictionaryWrapper(IDictionary<TKey, TValue> innerDictionary)
		{
			Contract.Requires<ArgumentNullException>(innerDictionary != null);
			this.innerDictionary = innerDictionary;
		}
		[ContractInvariantMethod]
		private void Invariant()
		{
			Contract.Invariant(innerDictionary != null);
		}
		public void Add(TKey key, TValue value)
		{
			innerDictionary.Add(key, value);
		}
		public bool ContainsKey(TKey key)
		{
			Contract.Ensures(Contract.Result<bool>() == innerDictionary.ContainsKey(key));
			return innerDictionary.ContainsKey(key);
		}
		public ICollection<TKey> Keys
		{
			get
			{
				return innerDictionary.Keys;
			}
		}
		public bool Remove(TKey key)
		{
			return innerDictionary.Remove(key);
		}
		public bool TryGetValue(TKey key, out TValue value)
		{
			return innerDictionary.TryGetValue(key, out value);
		}
		public ICollection<TValue> Values
		{
			get
			{
				return innerDictionary.Values;
			}
		}
		public TValue this[TKey key]
		{
			get
			{
				return innerDictionary[key];
			}
			set
			{
				innerDictionary[key] = value;
			}
		}
		public void Add(KeyValuePair<TKey, TValue> item)
		{
			innerDictionary.Add(item);
		}
		public void Clear()
		{
			innerDictionary.Clear();
		}
		public bool Contains(KeyValuePair<TKey, TValue> item)
		{
			return innerDictionary.Contains(item);
		}
		public void CopyTo(KeyValuePair<TKey, TValue>[] array, int arrayIndex)
		{
			innerDictionary.CopyTo(array, arrayIndex);
		}
		public int Count
		{
			get
			{
				Contract.Ensures(Contract.Result<int>() == innerDictionary.Count);
				return innerDictionary.Count;
			}
		}
		public bool IsReadOnly
		{
			get
			{
				return innerDictionary.IsReadOnly;
			}
		}
		public bool Remove(KeyValuePair<TKey, TValue> item)
		{
			return innerDictionary.Remove(item);
		}
		public IEnumerator<KeyValuePair<TKey, TValue>> GetEnumerator()
		{
			return innerDictionary.GetEnumerator();
		}
		IEnumerator IEnumerable.GetEnumerator()
		{
			return innerDictionary.GetEnumerator();
		}
	}
