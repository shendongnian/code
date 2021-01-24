    public class FakeHttpMessageHandler : HttpMessageHandler
    { 
        public string Content { get; set; }
    
        public virtual HttpResponseMessage Send(HttpRequestMessage request)
        {
            throw new NotImplementedException("Use Moq to overrite this method");
        }
    
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
        {
            MemoryStream msInput = new MemoryStream();
            await request.Content.CopyToAsync(msInput);
            byte[] byteInput = msInput.ToArray();
            msInput.Seek(0, SeekOrigin.Begin);
    
            Content = Encoding.UTF8.GetString(byteInput);
    
            return Send(request);
        }
    }
