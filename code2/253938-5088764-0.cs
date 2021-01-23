	class MyDictionary<TKey, TValue>
	{
		private Dictionary<TKey, TValue> _dict = new Dictionary<TKey, TValue>();
		private List<Keys> _keys = new List<TKey>();
		
		public void Add(TKey key, TValue value)
		{
			_dict.Add(key, value);
			_keys.Add(key);
		}
		
		//public bool Remove ...
		//indexer...
	}
