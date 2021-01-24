	public class ItemsController<T> : ControllerBase
	{
		private readonly ApiHttpCaller<T> _apiCaller;
		public ItemsController(ApiHttpCaller<T> apicaller){
			_apiCaller = apicaller;
		}
		[HttpPost]
		public async Task<ActionResult> Post([FromBody] string value)
		{
			// do something with the requested API Caller
		}
	}
