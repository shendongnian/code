	public interface IErrorCode
	{
        int HttpStatus { get; }
        string JsonErrorCode { get; }
	    void ThrowException(string pMsg);
	}
	
	public class ErrorCode<T> : IErrorCode where T : Exception
	{
		public int HttpStatus { get; private set; }
		public string JsonErrorCode { get; private set; }
		public ErrorCode(string pJsonErrorCode, int pHttpStatus)
		{
			this.HttpStatus = pHttpStatus;
			this.JsonErrorCode = pJsonErrorCode;
		}
		public void ThrowException(string pMsg)
		{
			var exception = (T)Activator.CreateInstance
            (
                typeof(T), 
                new object[] { pMsg }
            );
            throw exception;
		}
	}
	
	//Declare the dictionary with the interface, not the concrete type
	Protocol.ErrorCodes = new Dictionary<ErrorCodeType,IErrorCode>();
	
	Protocol.ErrorCodes.Add
	(
		ErrorCodeType.ElementClickIntercepted,
		new ErrorCode<ElementClickInterceptedException>
		(
			"element click intercepted", 
			400
		)
	);
