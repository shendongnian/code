    HttpWebResponse response;
    bool isValid = false;
    
    try
    {
        response = (HttpWebResponse)request.GetResponse();
        isValid = true;
    }
    catch (WebException we)
    {
        response = (HttpWebResponse)we.Response;
    }
    if (isValid)
    {
        // the response was valid
    }
    else
    {
        // the response returned a 400 error
    }
