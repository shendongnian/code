	var inputString = "iPhone 4";
	var token = inputString.ToLower().Replace(" ", "");
	
	var tokenizedQuery = Devices.Select(d => new { Device = d, Token = d.Name.ToLower().Replace(" ", "") });
	var filteredQuery = tokenizedQuery.Where(d => d.Token == token);
	var resultsQuery = filteredQuery.GroupBy(d => d.Token).Select(g => g.OrderByDescending(d => d.Device.Count).First());
	var results = resultsQuery.ToArray();
