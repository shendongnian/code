    bool hasDraftAccess = false;
    
    var query = DataContext.Records.AsQueryable();
    	
    if (!hasDraftAccess) {
    	query = query.Where(r => r.Status == 'A');
    }
    
    var seriesQuery = query.Select(r => new { Record = r, SeriesID = r.ParentID ?? r.ID });
    var latestQuery = seriesQuery.GroupBy(s => s.SeriesID).Select(g => g.OrderByDescending(s => s.Record.ID).First());
    var resultsQuery = latestQuery.Select(s => s.Record);
    var results = resultsQuery.ToArray();
