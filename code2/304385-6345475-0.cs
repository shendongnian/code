	public ActionResult DoSearch(FeederService.SearchRequestObject sourceRequestObject)
	{
		...
		var model = new MyAppMVC.Models.ResultsModel();
		var page = model.GetData(sourceRequestObject);
		return View("SearchResults", page);
	}
