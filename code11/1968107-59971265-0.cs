    public class WrapperHttpResponse
    {
        public HttpResponseMessage HttpResponseMessage { get; set; }
        public string Content { get; set; }
        public WrapperHttpResponse()
        {
        }
        public WrapperHttpResponse(HttpResponseMessage httpResponseMessage)
        {
            HttpResponseMessage = httpResponseMessage;
            Content = httpResponseMessage.Content.ReadAsStringAsync().GetAwaiter().GetResult();
        }
        public WrapperHttpResponse(HttpResponseMessage httpResponseMessage, string content)
        {
            HttpResponseMessage = httpResponseMessage;
            Content = content;
        }
    }
