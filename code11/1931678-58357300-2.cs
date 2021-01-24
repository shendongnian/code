    public class ProxyMiddleware : OwinMiddleware
    {
        private static HttpClient _httpClient = new HttpClient();
    
        public ProxyMiddleware(OwinMiddleware next)
            : base(next)
        {
        }
    
        public override async Task Invoke(IOwinContext context)
        {
            HttpRequestMessage request = new HttpRequestMessage(new HttpMethod(context.Request.Method), new Uri("http://SERVERURL/" + context.Request.Path));
            request.Content = new StreamContent(context.Request.Body);
            HttpResponseMessage response = await _httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead);
            context.Response.StatusCode = (int)response.StatusCode;
            await response.Content.CopyToAsync(context.Response.Body);
        }
    }
