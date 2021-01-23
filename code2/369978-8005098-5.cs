    public static DatedSetExtensions
	{
		public static IEnumerable<IDated> WhereHasDate(this IEnumerable<IDated> input)
		{
			return input.Where(x => x.Date.HasValue);
		}
	}
	
	...
	
    list = list.WhereHasDate();
