    public class ApiCallException : Exception
    {
        public int StatusCode { get; }
        public override string Message { get; }
        public ApiCallException(int statusCode, string message)
        {
            StatusCode = statusCode;
            Message = message;
        }
    }
