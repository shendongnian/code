    [DataContract]
    public class ApiErrorResult : ApiResult<IList<ErrorCodes>>
    {
        public ApiErrorResult(String message)
        {
            Code = ApiCode.ValidationError;
            Error = message;
        }
    }
