		static T FindFirst<T>(IEnumerable<T> col, Predicate<T> predicate)
		{
			foreach(T t in col)
			{
				if(predicate(t))
				{
					return t;
				}
			}
			return default(T);
		}
