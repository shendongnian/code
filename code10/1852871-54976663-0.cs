    public class InnerError {
        public string Message { get; set; }
        public string Type { get; set; }
        public string StackTrace { get; set; }
    }
    
    public class Error {
        public string Code { get; set; }
        public string Message { get; set; }
        public InnerError InnerError { get; set; }
    }
    
    public class ExceptionResponse {
        public Error Error { get; set; }
    }
