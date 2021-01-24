    public class OperationResult
    {
        protected OperationResult()
        {
            this.Success = true;
        }
        protected OperationResult(string message)
        {
            this.Success = false;
            this.FailureMessage = message;
        }
        protected OperationResult(Exception ex)
        {
            this.Success = false;
            this.Exception = ex;
        }
        public bool Success { get; protected set; }
        public string FailureMessage { get; protected set; }
        public Exception Exception { get; protected set; }
        public static OperationResult SuccessResult()
        {
            return new OperationResult();
        }
        public static OperationResult FailureResult(string message)
        {
            return new OperationResult(message);
        }
        public static OperationResult ExceptionResult(Exception ex)
        {
            return new OperationResult(ex);
        }
        public bool IsException()
        {
            return this.Exception != null;
        }
    }
