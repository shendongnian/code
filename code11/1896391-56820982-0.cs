		public class FetchViewComponentRequest<T>
		{
			public string ViewComponentName { get; set; }
			public T ViewModel { get; set; }
			//     ^^^^^^^^^^^^^^
		}
		
		[HttpGet]
		public IActionResult FetchViewComponent(FetchViewComponentRequest<BuyerViewModel> request)
		{
			return ViewComponent(request.ViewComponentName, request.ViewModel);
		}
