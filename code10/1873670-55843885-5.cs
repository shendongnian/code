    public class ErrorResult : IHttpActionResult
    {
        private readonly Error _error;
        private readonly HttpRequestMessage _request;
    
        public ErrorResult(Error error, HttpRequestMessage request)
        {
            _error = error;
            _request = request;
        }
    
        public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {
            var err = new Error()
            {
                Code = _error.Code,
                Message = _error.Message
            };
    
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<Error>(err, new JsonMediaTypeFormatter()),
                RequestMessage = _request
            };
            return Task.FromResult(response);
        }
    }
    
    public class Error
    {
        public string Code { get; set; }
        public string Message { get; set; }
    }
