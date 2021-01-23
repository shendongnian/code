	public static class OrderedDictionaryExtensions
	{
		public static int IndexOf(this OrderedDictionary dictionary, object value)
		{
			for(int i = 0; i < dictionary.Count; ++i)
			{
				if(dictionary[i] == value) return i;
			}
			return -1;
		}
	}
