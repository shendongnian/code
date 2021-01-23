    HttpWebResponse response;
    try
    {
        response = (HttpWebResponse)request.GetResponse();
    }
    catch (WebException ex)
    {
        response = (HttpWebResponse)ex.Response;
    }
