    public class CustomResult : IActionResult
    {
        private readonly string _errorMessage;
        private readonly int _statusCode;
        public CustomResult(string errorMessage, int statusCode)
        {
            _errorMessage = errorMessage;
            _statusCode = statusCode;
        }
        public async Task ExecuteResultAsync(ActionContext context)
        {
            var objectResult = new ObjectResult(_errorMessage)
            {
                StatusCode = _statusCode
            };
            await objectResult.ExecuteResultAsync(context);
        }
    }
