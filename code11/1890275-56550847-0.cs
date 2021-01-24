	using (var db = new ApplicationDbContext())
	{
		return db.Categories.ToList().Select(d => new SelectListItem()
		{
			Text = d.Title,
			Value = d.Id.ToString()
		});
	}
	
