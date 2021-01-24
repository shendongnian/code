    public static class Extension
    {
        public const string _ERROR = "ErrorMessage";
    
        public static void SetErrorMessage(this ITempDataDictionary @this, string message)
        {
            @this[_ERROR] = message;
        }
        public static string GetErrorMessage(this ITempDataDictionary @this) =>
            @this[_ERROR]?.ToString();
    }
