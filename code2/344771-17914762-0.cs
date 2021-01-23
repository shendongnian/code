	[DataContract]
	public class WebServiceFault
	{
		public WebServiceFault(Exception ex)
		{
			Message = ex.Message;
			InnerException = new ExceptionDetail(ex);
		}
		[DataMember]
		public string Message
		{
			get;
			private set;
		}
		[DataMember]
		public ExceptionDetail InnerException
		{
			get;
			private set;
		}
	}
