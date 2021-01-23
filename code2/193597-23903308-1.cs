	public async Task<bool> IsAccessibleAsync (string url)
	{
		if (url == null)
			throw new ArgumentNullException ("url");
		if (url.IndexOf (':') < 0)
			url = "http://" + url.TrimStart ('/');
		if (!Uri.IsWellFormedUriString (url, UriKind.Absolute))
			return false;
		var request = (HttpWebRequest) WebRequest.Create (url);
		request.Method = "HEAD";
		try
		{
			using (var response = await request.GetResponseAsync () as HttpWebResponse)
			{
				if (response != null && response.StatusCode == HttpStatusCode.OK)
					return true;
				return false;
			}
		}
		catch (WebException)
		{
			return false;
		}
	}
