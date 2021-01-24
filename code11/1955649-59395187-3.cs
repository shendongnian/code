	[HttpPost]
	[ValidateAntiForgeryToken]
	public ActionResult RemoveThing(int barId)
	{
		System.Diagnostics.Debug.WriteLine("DEBUG: aaaa");    
		try {
			return RedirectToAction("List");
		}
		catch (Exception e)
		{
			throw new Exception(e.Message);
		}
	}
