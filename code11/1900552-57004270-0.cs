	var approveposts = 
		db.Announcement_Categories
			.Where(a => a.Announcement.Announcement_Approvers.Any() == false)
			.GroupBy(a => a.Category);
	foreach (var categorygroup in approveposts)
	{
		var category = categorygroup.Key;
		var posts = categorygroup.ToList();
	
		// Find parents
		var parents = new List<Category>();
		var parentcategory = category.Parent;
		while (parentcategory != null)
		{
			parents.Insert(0, parentcategory);
			parentcategory = parentcategory.Parent;
		}
		
		// Show data
		
	}
