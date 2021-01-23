	public static class Extended 
	{
		public static IEnumerable<int> Even(this IEnumerable<int> numbers, 
											Predicate<int> predicate = null)
		{
			if (predicate==null)
			{
				predicate = i=>true;
			}
		
			return numbers.Where(num => num % 2 == 0 && predicate(num));
		}
	}
