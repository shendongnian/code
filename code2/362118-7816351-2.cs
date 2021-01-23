	public static IQueryable<Post> WhereStatusVisible(
		this IQueryable<Post> posts)
	{
		return
			from p in posts
			where p.StatusID == (int)PostStatus.Visible
			select p;
	}
	
	public static IQueryable<Post> OrderByDateCreatedDescending(
		this IQueryable<Post> posts)
	{
		return
			from p in posts
			orderby p.DateCreated descending
			select p;
	}
