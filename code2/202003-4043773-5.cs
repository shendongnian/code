    [Serializable]
    public class RulesException : Exception 
    {
        public IEnumerable<ErrorInfo> Errors { get; private set; }
        public RulesException(IEnumerable<ErrorInfo> errors)
        {
            Errors = errors != null ? errors : new List<ErrorInfo>();
        }
        public RulesException(string propertyName, string errorMessage) : 
            this(propertyName, errorMessage, null)
        {
            
        }
        public RulesException(string propertyName, string errorMessage, object onObject) : 
            this (new ErrorInfo[] { new ErrorInfo(propertyName, errorMessage, onObject) } )
        {
        }
    }
