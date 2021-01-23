    [Serializable]
    public class ErrorInfo
    {
        public string ErrorMessage { get; private set; }
        public object Object { get; private set; }
        public string PropertyName { get; private set; }
        public ErrorInfo(string propertyName, string errorMessage)
            : this(propertyName, errorMessage, null)
        {
        }
        public ErrorInfo(string propertyName, string errorMessage, object onObject)
        {
            PropertyName = propertyName;
            ErrorMessage = errorMessage;
            Object = onObject;
        } 
    }
