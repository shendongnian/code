	private readonly HttpClient _client;
	
	public ClassConstructor(HttpClient client)
	{
		_client = client ?? new HttpClient();		
	}
