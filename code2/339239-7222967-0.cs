    bool hasDraftAccess = true;
	
	var query = DataContext.Drafts.AsQueryable();
		
	if (!hasDraftAccess) {
		query = query.Where(r => r.Status == 'A');
	}
	
	var seriesQuery = query.Select(r => new { ID = r.ID, SeriesID = r.ParentID ?? r.ID, Status = r.Status });
	var resultsQuery = seriesQuery.GroupBy(r => r.SeriesID).Select(g => g.OrderByDescending(r => r.ID).First());
	
	var results = resultsQuery.ToArray();
