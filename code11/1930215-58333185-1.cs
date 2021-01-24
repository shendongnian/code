    // Define InputStatus enum, which represents all available statuses
    
    public async Task<InputStatus> GetValidInputStatus(string url)
    {
        var httpClient = new HttpClient(); // or better inject it into controller
        var httpReq = new HttpRequestMessage();
    
        httpReq.Method = HttpMethod.Post;
        httpReq.RequestUri = new Uri(url);
    
        var response = await httpClient.SendAsync(httpReq);
        var content = await response.Content.ReadAsStringAsync();
    
        // Parse content string somehow into an InputStatus
        InputStatus validStatus = ParseStatus(content);
    
        return validStatus;
    }
    
    [HttpPost]
    public Task<JsonResult> UpdateTicketFromDetails()
    {
        var ticketStatusInput = Request.Form["ticketStatusInput"]; // Convert it to InputStatus model somehow
        var validStatus = await GetValidInputStatus(url); // Put here the same url as in your ajax call on the UI
    
        if (validStatus == InputStatus.TMN && 
    	    (ticketStatusInput == InputStatus.ABT || ticketStatusInput == InputStatus.CDO || ticketStatusInput == InputStatus.ESU))
        // throw, user sent disabled statuses
        else
        // continue
    }
