    if (e.Status == WebExceptionStatus.ProtocolError) 
    {
        Console.WriteLine("Status Code : {0}", ((HttpWebResponse)e.Response).StatusCode);
        Console.WriteLine("Status Description : {0}", ((HttpWebResponse)e.Response).StatusDescription);
    }
