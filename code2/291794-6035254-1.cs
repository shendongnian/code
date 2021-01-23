    public static class ErrorHandler
    {
        public static string ToErrorString(this ErrorCode errorCode)
        {
            return Enum.IsDefined(typeof(ErrorCode), errorCode) ? 
                errorCode.ToString() : "Undefined error code";
        }
    }
