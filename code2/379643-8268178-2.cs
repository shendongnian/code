    try
    {
        var request = WebRequest.Create("http://localhost:5984/booster");
        request.Headers.Clear();
        request.Headers["Authorization"] = "Basic " + Convert.ToBase64String(Encoding.Default.GetBytes("admin:123"));
        request.Method = "DELETE";
        var response = request.GetResponse();
        Console.WriteLine(response.GetResponseString());
    }
    catch (WebException e)
    {
        Console.WriteLine(e.Response.GetResponseString());
    }
