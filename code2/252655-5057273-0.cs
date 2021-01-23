    public class ErrorCodeException : Exception
    {
        private readonly int _errorCode;
        public ErrorCodeException(int errorCode)
        {
            _errorCode = errorCode;
        }
        public ErrorCodeException(int errorCode, string message)
            : base(message)
        {
            _errorCode = errorCode;
        }
        public int ErrorCode { get { return _errorCode; } }
    }
