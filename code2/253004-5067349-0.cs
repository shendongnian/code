	using (StreamReader stream = new StreamReader(file.OpenRead(), Encoding))
	{
		char[] buffer = new char[chunksize];
		while (stream.Peek() >= 0)
		{
			try
			{
				int readCount = stream.Read(buffer, 0, chunksize);
				yield return ReturnData( new string(buffer, 0, readCount));
			}
			catch(Exception exc)
			{
				yield return new ReturnData(exc);
			}
		}
	 }
	public class ReturnData
	{
		public string Data { get; private set;}
		public Exception { get; private set; }
		public bool HasError { get { return Exception != null; }}
		public ReturnData(string data)
		{
			this.Data = data;
		}
		public ReturnData(Exception exc)
		{
			this.Exception = exc;
		}
		
	}
