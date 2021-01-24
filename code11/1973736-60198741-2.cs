    class TestMessageHandler : HttpMessageHandler {
        private readonly IDictionary<string, HttpResponseMessage> messages;
        public TestMessageHandler(IDictionary<string, HttpResponseMessage> messages) {
            this.messages = messages;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = messages[request.RequestUri.ToString()] ?? new HttpResponseMessage(HttpStatusCode.NotFound);
            response.RequestMessage = request;
            return Task.FromResult(response);
        }
    }
