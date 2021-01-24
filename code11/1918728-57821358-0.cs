	public IActionResult Index()
		{
			return RedirectToAction("Error", "Home", new ErrorViewModel
			{
				RequestId = "Home",
				ControllerName = "Home Controller",
				ActionName = "Index",
				ErrorMessage = "Error Message 1"
			});
		}
		[AllowAnonymous]
		public IActionResult Error(ErrorViewModel error)
		{
			log.Log(error);
			return View(new ErrorViewModel
			{ RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
