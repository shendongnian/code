	public IQueryable<Post> GetNewest()
	{
		return
			from p in db.Posts
			where p.StatusID == (int)PostStatus.Visible
			orderby p.DateCreated descending
			select p;
	}
