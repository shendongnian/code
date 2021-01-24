    public async Task<List<Common.ProgressResponse>> RunAsync()
    {
        List<Response> ListOfResponses = new List<Responses>();
    
        try
        {
    		_client.BaseAddress = new Uri([URL]);
            ListOfResponses = await SomeFunction();
    
        }
        catch (Exception ex)
        {
            //Exceptions here...
        }
        return ListOfResponses;
    }
    
    
    private async Task<List<ListOfResponses>> SomeFunction()
    {
        List<Response> responses = new List<Response>();
        string aPISuffix = string.Format("{0}/{1}", [APISUFFIX1], [APISUFFIX2]);
    
        foreach (Object obj in ListOfObject)
        {
    		/*Moved Code .begin.*/
            _client.DefaultRequestHeaders.Accept.Clear();
            _client.DefaultRequestHeaders.Clear();
            _client.DefaultRequestHeaders.CacheControl = new CacheControlHeaderValue() { NoCache = true };
            _client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            _client.DefaultRequestHeaders.Add([KEY], [VALUE]);		
    		
    		/*Moved Code .end.*/
    		
            _client.DefaultRequestHeaders.Add("Param1", obj.Param1);
            if (!string.IsNullOrEmpty(obj.Param2))
                _client.DefaultRequestHeaders.Add("Param2", obj.Param2);
    
            Response response = new Response();
            HttpResponseMessage hTTPResponse = await _client.GetAsync(aPISuffix).ConfigureAwait(false);
    
            if (hTTPResponse.IsSuccessStatusCode)
            {
    	        string result = hTTPResponse.Content.ReadAsStringAsync().Result;		
                response = [Code here...]
                //Codes here...
            }
    
            responses.Add(response);
        }
    
        return responses;
    }
