	protected int AnimalCount(params System.Linq.Expression<System.Func<Animal, bool>>[] expressions)
	{
		var records = DbContext.Animal as IQueryable<Animal>;
		foreach (var expression in expressions)
		  records = records.Where(expression);
		return records.Count();
	}
