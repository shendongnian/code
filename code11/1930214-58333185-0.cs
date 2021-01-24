    // Define InputStatus enum, which represents all available statuses
    
    public async Task<List<InputStatus>> GetValidInputStatuses(string url)
    {
    	var httpClient = new HttpClient(); // or better inject it into controller
    	var httpReq = new HttpRequestMessage();
    
    	httpReq.Method = HttpMethod.Post;
    	httpReq.RequestUri = new Uri(url);
    
    	var response = await httpClient.SendAsync(httpReq);
    	var content = await response.Content.ReadAsStringAsync();
    
    	// Parse content string somehow into a list of InputStatuses
    	List<InputStatus> validStatuses = ParseStatuses(content);
    	
    	return validStatuses;
    }
    
    [HttpPost]
    public Task<JsonResult> UpdateTicketFromDetails()
    {
    	var ticketStatusInput = Request.Form["ticketStatusInput"]; // Convert it to InputStatus model somehow
    	var validStatuses = await GetValidInputStatuses(url); // Put here the same url as in your ajax call on the UI
    	
    	if (validStatuses.Contains(ticketStatusInput))
    	// continue
    	else
    	// throw error
    }
