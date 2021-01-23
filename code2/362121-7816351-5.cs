	public static IQueryable<Post> GetByCategories(
		this IQueryable<Post> posts,
		IQueryable<Category> categories)
	{
		return
			from p in posts
			join c in categories on p.CategoryId equals c.Id
			select p;
	}
	
	public static IQueryable<Category> WhereStartsWith(
		this IQueryable<Category> categories,
		string startsWith)
	{
		return
			from c in categories
			where c.Name.StartsWith(startsWith)
			select c;
	}
