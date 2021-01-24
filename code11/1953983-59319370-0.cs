    try 
    {
        //...
    } 
    catch (Exception ex) 
    {
        var clientEx = ex.IsAny400();
        var notFound = ex.IsNotFound();
    
        HttpStatusCode? errorStatus = ex.GetStatus(); // HTTP Status Code
        string errorBody = ex.GetResponseBody();      // Error Response Body (if any)
        var errorResponse = (HttpWebResponse)ex.Response;
        var description = errorResponse.StatusDescription;
    }
