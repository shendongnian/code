    public class ImplicitReturnResult
    {
        public static implicit operator ReturnResult(OkResult result)
        {
            return new ReturnResult(true, ResultStatus.Success);
        }
    }
