		public static T GetNext<T>(IList<T> collection, T value )
		{
			int nextIndex = collection.IndexOf(value) + 1;
			if (nextIndex < collection.Count)
			{
				return collection[nextIndex];
			}
			else
			{
				return value; //Or throw an exception
			}
		}
