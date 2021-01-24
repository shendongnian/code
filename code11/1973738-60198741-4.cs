    class TestMessageHandler : HttpMessageHandler {
        private readonly IDictionary<string, HttpResponseMessage> messages;
        public TestMessageHandler(IDictionary<string, HttpResponseMessage> messages) {
            this.messages = messages;
        }
        protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken) {
            var response = new HttpResponseMessage(HttpStatusCode.NotFound);
            if (messages.ContainsKey(request.RequestUri.ToString()))
                response = messages[request.RequestUri.ToString()] ?? new HttpResponseMessage(HttpStatusCode.NoContent);
            response.RequestMessage = request;
            return Task.FromResult(response);
        }
    }
