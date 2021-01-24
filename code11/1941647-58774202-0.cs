	public interface IErrorCode
	{
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
			throw Activator.CreateInstance(typeof(T), pMsg);
		}
	}
	
	//Declare the dictionary with the interface, not the concrete type
	Protocl.ErrorCodes = new Dictionary<ErrorCodeType,IErrorCode>();
	
	Protocol.ErrorCodes.Add
	(
		ErrorCodeType.ElementClickIntercepted,
		new ErrorCode<ElementClickInterceptedException>
		(
			"element click intercepted", 
			400
		)
	);
