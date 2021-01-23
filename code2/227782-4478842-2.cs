		public static void AddOrUpdate<K, V>(this List<KeyValuePair<K, V>> list, K key, V value)
		{
			var pair = list.SingleOrDefault(kvp => kvp.Key.Equals(key));
			if (!pair.Equals(null))
				list.Remove(pair);
			list.Add(new KeyValuePair<K, V>(key, value));
		}
		public static V GetValue<K, V>(this List<KeyValuePair<K, V>> list, K key)
		{
			var pair = list.SingleOrDefault(kvp => kvp.Key.Equals(key));
			if (pair.Equals(null))
				return default(V); //or throw an exception
			return pair.Value;
		}
		public static bool ContainsKey<K, V>(this List<KeyValuePair<K, V>> list, K key)
		{
			return list.Any(kvp => kvp.Key.Equals(key));
		}
