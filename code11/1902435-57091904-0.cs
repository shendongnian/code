    public interface IMessageTransport
    {
        Task SendMessageAsync(string message);
    }
    // In ADLS_Operations ctor:
    public ADLS_Operations(IMessageTransport messageTransport)
    { 
        //...
    }
    
    public class HttpMessageTransport : IHttpMessageTransport
    {
        public HttpMessageTransport()
        {
            this.httpClient = //get the http client somewhere.
        }
        
        public Task SendMessageAsync(string message)
        {
            return this.httpClient.PostAsync(message);
        }
    }
