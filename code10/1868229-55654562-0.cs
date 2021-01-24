	HttpResponseMessage httpResponseMessage = null;
    using (var content = new ByteArrayContent(Encoding.UTF8.GetBytes("Hello")))
    {
        var httpRequestMessage = new HttpRequestMessage(HttpMethod.Post, "http://SomeUrl")
        {
            Content = content,
            Version = HttpVersion.Version10
        };
		
		using (var httpClient = new HttpClient(httpClientHandler, disposeHandler))
		{
			httpResponseMessage = await httpClient.SendAsync(httpRequestMessage);
		}
    }
