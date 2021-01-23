    try
    {
        // ...
    }
    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError)
        {
            var response = ex.Response as HttpWebResponse;
            if (response != null)
            {
                Console.WriteLine("HTTP Status Code: " + (int)response.StatusCode);
            }
            else
            {
                // no http status code available
            }
        }
        else
        {
            // no http status code available
        }
    }
