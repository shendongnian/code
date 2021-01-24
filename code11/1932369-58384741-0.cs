	public class FileResult : IHttpActionResult
	{
		private byte[] _content;
		private string _contentType;
		public FileResult(byte[] content, string contentType)
		{
			_content = content;
			_contentType = contentType;
		}
		public Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
		{
			if (cancellationToken.IsCancellationRequested)
				return null;
			// per https://stackoverflow.com/questions/9541351/returning-binary-file-from-controller-in-asp-net-web-api do not wrap this in a using block
			System.IO.MemoryStream stream = new System.IO.MemoryStream(_content);
			stream.Seek(0, System.IO.SeekOrigin.Begin);
			HttpResponseMessage response = new HttpResponseMessage(System.Net.HttpStatusCode.OK);
			response.Content = new StreamContent(stream);
			response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(_contentType);
			return Task.FromResult(response);
		}
	}
