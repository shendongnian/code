    catch (WebException ex)
    {
        if (ex.Status == WebExceptionStatus.ProtocolError)
        {
            var statusCode = ((HttpWebResponse)ex.Response).StatusCode;
            // Test against HttpStatusCode enumeration.
        }
        else
        {
            // Do something else, e.g. throw;
        }
    }
