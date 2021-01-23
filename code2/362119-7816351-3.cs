	public static IEnumerable<PostViewModel> ToPostViewModels(
		this IQueryable<Post> posts,
		IQueryable<User> users)
	{
		var query =
			from p in posts
			join u in users on p.AuthorId equals u.Id
			select new { p, u };
		return
			query
				.ToArray()
				.Select(q => new PostViewModel()
				{
					Id = q.p.Id,
					DateCreated = q.p.DateCreated,
					AuthorName = q.u.Name,
				})
				.ToArray();
	}
