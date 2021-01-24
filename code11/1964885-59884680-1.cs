	public class RequestToSwapiApi
	{
		private readonly IHttpClientFactory _clientFactory;
		public RequestToSwapiApi(IHttpClientFactory httpClientFactory)
		{
			_clientFactory = clientFactory;
		}
		public async Task<RootObject> ReturnTheStarShipModels()
		{
			HttpClient client = _clientFactory.CreateClient();
			//...
