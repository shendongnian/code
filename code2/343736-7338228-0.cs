	public static void LookupAdd<T,V>(this Dictionary<T, List<V>> dict, T key, V item)
	{
		if (!dict.ContainsKey(key))
		{
			dict.Add(key, new List<V>());
		}
		dict[key].Add(item);
	}
