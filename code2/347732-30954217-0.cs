	public static IEnumerable<T> GetNonShared<T>(this IEnumerable<IEnumerable<T>> list)
	{
		var lstCnt=list.Count(); //get the total number if items in the list								
		return list.SelectMany (l => l.Distinct())
			.GroupBy (l => l)
			.Select (l => new{n=l.Key, c=l.Count()})
			.Where (l => l.c<lstCnt)
			.Select (l => l.n)
			.OrderBy (l => l) //can be commented
			;
	}
