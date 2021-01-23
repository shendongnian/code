	try
	{
		DataTable dt = q.ExecuteQuery(); //This throws a timeout.
	}
	catch (SessiontTimeoutException ste)
	{
		throw new MyException("my friendly exception message", ex);
	}
	[Serializable]
	public class MyException : Exception
	{
		public MyException() { }
		public MyException(string message) : base(message) { }
		public MyException(string message, Exception inner) : base(message, inner) { }
		protected MyException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
