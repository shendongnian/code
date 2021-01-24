    private static void TryHttpClientWithServicePoint()
    {
        var webRequestHandler = SetServicePointOptions(new WebRequestHandler());
        var client = new HttpClient(webRequestHandler);
        var content = client.GetStringAsync("https://stackoverflow.com").Result;
        Console.WriteLine(content.Substring(0, 256));
    }
    private static WebRequestHandler SetServicePointOptions(WebRequestHandler handler)
    {
        var field = typeof(HttpClientHandler).GetField("_startRequest",
            BindingFlags.NonPublic | BindingFlags.Instance); // Fieldname has a _ due to being private
        var startRequest = (Action<object>) field.GetValue(handler);
        Action<object> newStartRequest = obj =>
        {
            var webReqField = obj.GetType().GetField("webRequest", BindingFlags.NonPublic | BindingFlags.Instance);
            var webRequest = webReqField.GetValue(obj) as HttpWebRequest;
            webRequest.ServicePoint.BindIPEndPointDelegate = BindIPEndPoint;
            startRequest(obj); //call original action
        };
        field.SetValue(handler, newStartRequest); //replace original 'startRequest' with the one above
        return handler;
    }
    public static IPEndPoint BindIPEndPoint(ServicePoint servicePoint, IPEndPoint remoteEndPoint, int retryCount)
    {
        Console.WriteLine($"IP address = {remoteEndPoint}");
        return null;
    }
