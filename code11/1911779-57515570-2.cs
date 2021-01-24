    [HttpGet]
    public HttpResponseMessage GetTableRecordCounts()
    {
	    var jsonString = ProcWrapper.GetDataJSON("GetTableRecordCounts");
	    HttpResponseMessage success = Request.CreateResponse(HttpStatusCode.OK);
	    success.Content = new StringContent(jsonString, Encoding.UTF8, "application/json");
	    return success;
    }
	
