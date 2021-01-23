	public class MultiDictionary<TKey, TValue>
	{
		private Dictionary<TKey, List<TValue>> data = new Dictionary<TKey, List<TValue>>();
		public struct Entry : IEnumerable<TValue>
		{
			private readonly MultiDictionary<TKey, TValue> mDictionary;
			private readonly TKey mKey;
			public TKey Key { get { return mKey; } }
			public bool IsEmpty
			{
				get
				{
					return !mDictionary.data.ContainsKey(Key);
				}
			}
			public void Add(TValue value)
			{
				List<TValue> list;
				if (!mDictionary.data.TryGetValue(Key, out list))
					list = new List<TValue>();
				list.Add(value);
				mDictionary.data[Key] = list;
			}
			public bool Remove(TValue value)
			{
				List<TValue> list;
				if (!mDictionary.data.TryGetValue(Key, out list))
					return false;
				bool result = list.Remove(value);
				if (list.Count == 0)
					mDictionary.data.Remove(Key);
				return result;
			}
			public void Clear()
			{
				mDictionary.data.Remove(Key);
			}
			internal Entry(MultiDictionary<TKey, TValue> dictionary, TKey key)
			{
				mDictionary = dictionary;
				mKey = key;
			}
			public IEnumerator<TValue> GetEnumerator()
			{
				List<TValue> list;
				if (!mDictionary.data.TryGetValue(Key, out list))
					return Enumerable.Empty<TValue>().GetEnumerator();
				else
					return list.GetEnumerator();
			}
			System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
			{
				return GetEnumerator();
			}
		}
		public Entry this[TKey key]
		{
			get
			{
				return new Entry(this, key);
			}
		}
	}
