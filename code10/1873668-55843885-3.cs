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
            var errorList = new List<Error> {_error};
    
            var err = new Errors()
            {
                ErrorList = errorList
            };
    
            var response = new HttpResponseMessage(HttpStatusCode.BadRequest)
            {
                Content = new ObjectContent<Errors>(err, new JsonMediaTypeFormatter()),
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
    
    public class Errors
    {
        public List<Error> ErrorList { get; set; }
    }
