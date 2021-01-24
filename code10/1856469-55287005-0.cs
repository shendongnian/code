    [EnableQuery]
    public IHttpActionResult Get()
    {
    	var displayData = _dataService.RetrieveData().AsQueryable();
    
    	return Ok(displayData);
    }
