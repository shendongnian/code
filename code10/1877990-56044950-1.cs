    public static string GenerateLink(HttpRequestMessage httpRequest)
    {
        var urlHelper = new UrlHelper(httpRequest).Route("DefaultApi", new
        {
            Controller = "MyController",
            Action = "MyAction"
        });
        return httpRequest.RequestUri.Scheme + "://" + httpRequest.RequestUri.Authority + urlHelper;
    }
