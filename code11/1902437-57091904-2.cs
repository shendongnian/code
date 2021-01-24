    // Now you mock this interface instead, which is a pretty simple task.
    // I suggest also abstracting away from an HttpResponseMessage
    // This would allow you to swap for any other transport in the future. All 
    // of the response error handling could be done inside the message transport 
    // class.  
    public interface IMessageTransport
    {
        Task SendMessageAsync(string message);
    }
    // In ADLS_Operations ctor:
    public ADLS_Operations(IMessageTransport messageTransport)
    { 
        //...
    }
    
    public class HttpMessageTransport : IMessageTransport
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
