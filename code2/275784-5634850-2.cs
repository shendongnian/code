    var request = (HttpWebRequest)WebRequest.Create("http://www.http500.com");
    try
    {
        var response = request.GetResponse();
    }
    catch (WebException wex)
    {
        // Safe cast to HttpWebResponse using 'as', will return null if unsuccessful
        var httpWebResponse = wex.Response as HttpWebResponse;
        if(httpWebResponse != null)
        {
            var httpStatusCode = httpWebResponse.StatusCode;
            // HttpStatusCode is an enum, cast it to int for its actual value
            var httpStatusCodeInt = (int)httpWebResponse.StatusCode;                    
        }
    }
