	private async Task SetEndPointValueAsync(Uri stunnelUri, string username, string password)
	{
		if (stunnelUri == null) throw new ArgumentNullException(nameof(stunnelUri));
		if (String.IsNullOrEmpty(username)) throw new ArgumentNullException(nameof(username));
		if (String.IsNullOrEmpty(password)) throw new ArgumentNullException(nameof(password));
		byte[] byteArray = Encoding.ASCII.GetBytes($"{username}:{password}");
		string scheme = "Basic";
		string parameter = Convert.ToBase64String(byteArray);
		
		HttpRequestMessage request = new HttpRequestMessage();
		request.Method = HttpMethod.Post;
		request.RequestUri = stunnelUri;
		request.Headers.Authorization = new AuthenticationHeaderValue(scheme, parameter);
		try
		{
			HttpResponseMessage response = await _client.SendAsync(request);
			// This will throw an HttpRequestException if there is a failure above
			response.EnsureSuccessStatusCode();
			
			// do your stuff here...
			// { ... }
			
		}
		catch (HttpRequestException)
		{
			// { log your connection / bad request issue. }
		}
		catch (Exception) 
		{
			// I don't recommend this, but since you had it...
			// { handle all other exceptions }
		}
	}
