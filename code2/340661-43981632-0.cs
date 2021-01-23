    try
    {
        response = basicHTTPBindingClient.CallOperation(request);
    }
    catch (ProtocolException exception)
    {
        var webException = exception.InnerException as WebException;
        var rawResponse = string.Empty;
    
        var alreadyClosedStream = webException.Response.GetResponseStream() as MemoryStream;
        using (var brandNewStream = new MemoryStream(alreadyClosedStream.ToArray()))
        using (var reader = new StreamReader(brandNewStream))
            rawResponse = reader.ReadToEnd();
    }
