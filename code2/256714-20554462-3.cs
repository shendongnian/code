	bool CheckUncPath(string s) {
		// Get the server name
		Uri uri = new Uri(s);
		if (uri.Segments.Length == 0 || string.IsNullOrWhiteSpace(uri.Host))
			return false;
		if (uri.Host != Dns.GetHostName()) {
			WebRequest request;
			WebResponse response;
			request = WebRequest.Create(uri);
			request.Method = "HEAD";
			request.Timeout = 120;
			try {
				response = request.GetResponse();
			} catch (Exception ex) {
				return false;
			}
			return response.ContentLength > 0;
		}
		return File.Exists(s);
	}
