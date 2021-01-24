    public class ProcessResult
    {
        public ProcessResult(int statusCode) : this(statusCode, null) {}
        public ProcessResult(int statusCode, IEnumerable<string> errors)
        {
            Succeeded = statusCode < 300;
            StatusCode = statusCode;
            Errors = errors;
        }
        public bool Succeeded { get; private set; }
        public int StatusCode { get; private set; }
        public IEnumerable<string> Errors { get; private set; }
    }
