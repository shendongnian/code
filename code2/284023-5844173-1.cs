<pre>
		private Dictionary < object, T > dictionary = null;
		public bool ContainsField(IEnumerable < T > array, string fieldname, object obj)
		{
			if (dictionary == null) // first call, build dictionary
			{
				dictionary = new Dictionary< object, T >();
				foreach (T val in array)
					dictionary[val.GetType().GetField(fieldname).GetValue(val)] = val;
			}
			return dictionary.ContainsKey(obj); // every call use dictionary
		}
</pre>
