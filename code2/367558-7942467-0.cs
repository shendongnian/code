	public static class MyEnumerableExtensions
	{
		public static IEnumerable<T> SkipAt<T>(this IEnumerable<T> list, int index)
		{
			var i = 0;
	
			foreach(var item in list) 
			{
				if(i != index)
					yield return item;
	
				i++;
			}
		}
	}
