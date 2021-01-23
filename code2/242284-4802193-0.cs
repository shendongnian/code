    try
    {
        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
        response.ContentLength64 = buffer.Length;
        output.Write(buffer, 0, buffer.Length);
    }
    catch (HttpListenerException)
    {
        // Handle error caused by connection being lost
    }
