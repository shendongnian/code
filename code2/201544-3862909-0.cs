    WebRequest request = WebRequest.Create(URL);
    request.Method = "HEAD";
    try
    {
        using (WebResponse response = request.GetResponse())
        {
            // Use data for success case
        }
    }
    catch (WebException ex)
    {
        HttpWebResponse errorResponse = (HttpWebResponse) ex.Response;
        HttpStatusCode status = errorResponse.StatusCode;
        // etc
    }
