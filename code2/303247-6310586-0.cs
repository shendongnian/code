        public class StatusKillerMessageHandler : DelegatingChannel {
        public StatusKillerMessageHandler(HttpMessageChannel innerChannel)
            : base(innerChannel) {
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            bool suppressStatusCode = (request.RequestUri.AbsoluteUri.ToLower().Contains("suppress=true"));
            
            return base.SendAsync(request, cancellationToken).ContinueWith<HttpResponseMessage>(task => {
                            
                       var response = task.Result;
                       if (suppressStatusCode) {
                            response.StatusCode = HttpStatusCode.OK;
                       }
                       return response;
                    });
        }
    }
