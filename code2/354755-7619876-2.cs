    public class ErrorInfo
    {
        public string Message {get; set;}
        // TODO: Maybe add in other information about the error?
    }
    public class SaveResult
    {
        public bool Success { get; set; }
        /// <summary>
        /// Set to contain error information if Success = false
        /// </summary>
        public ErrorInfo ErrorInfo { get; set; }
    }
