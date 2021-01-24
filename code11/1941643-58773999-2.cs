    public class ErrorCode
    {
      public int HttpStatus { get; private set; }
      public string JsonErrorCode { get; private set; }
      public Type ExceptionT { get; private set; }
      public ErrorCode(string pJsonErrorCode, int pHttpStatus, Type pExceptionType)
      {
        this.HttpStatus = pHttpStatus;
        this.JsonErrorCode = pJsonErrorCode;
        this.ExceptionT = pExceptionType;
      }
      public void ThrowException(string pMsg)
      {
        throw (Exception)Activator.CreateInstance(ExceptionT, pMsg);
      }
    }
