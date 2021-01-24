	[HttpPost]
	public ActionResult Test()
	{
		var x = Request.Form["test"].First();
		var y = Request.Form["test2"].First();
		return RedirectToAction("Index");
	}
	
