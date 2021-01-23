	var inputString = "iPhone 4";
	var token = inputString.ToLower().Replace(" ", "");
	
	var tokenizedQuery = DataContext.Devices.Select(d => new { Device = d, Token = d.Name.ToLower().Replace(" ", "") });
	var filteredQuery = tokenizedQuery.Where(d => d.Token == token);
	var resultsQuery = filteredQuery.Select(d => d.Device).OrderByDescending(d => d.Count);
	var result = resultsQuery.FirstOrDefault();
