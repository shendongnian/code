    try {
    	return query.FirstOrDefault();
    }
    catch (System.Data.Services.Client.DataServiceQueryException ex)
    {
    	if (ex.Response.StatusCode == (int)System.Net.HttpStatusCode.NotFound) {
    		return null;
    	}
    	throw;
    }
