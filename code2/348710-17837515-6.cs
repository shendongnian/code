    public class MyWorkerRequest : SimpleWorkerRequest
	{
		private readonly string _size;
		private readonly Stream _data;
		private string _contentType;
		public MyWorkerRequest(Stream data, string size, string contentType)
			: base("/app", @"c:\", "aa", "", null)
		{
			_size = size ?? data.Length.ToString(CultureInfo.InvariantCulture);
			_data = data;
			_contentType = contentType;
		}
		public override string GetKnownRequestHeader(int index)
		{
			switch (index)
			{
				case (int)HttpRequestHeader.ContentLength:
					return _size;
				case (int)HttpRequestHeader.ContentType:
					return _contentType;
			}
			return base.GetKnownRequestHeader(index);
		}
		public override int ReadEntityBody(byte[] buffer, int offset, int size)
		{
			return _data.Read(buffer, offset, size);
		}
		public override int ReadEntityBody(byte[] buffer, int size)
		{
			return ReadEntityBody(buffer, 0, size);
		}
	}
