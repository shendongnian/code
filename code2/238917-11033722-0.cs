	public class RequestDictionary : IDictionary<string, string>
	{
		private HttpRequest request;
		public RequestDictionary(HttpRequest request)
		{
			this.request = request;
		}
		public string this[string key] {
			get { return request(key); }
			set {
				throw new NotImplementedException();
			}
		}
        // ...
	}
