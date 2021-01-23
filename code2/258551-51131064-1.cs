		[HttpPost]
		public ActionResult Index(HttpPostedFileBase upload)
		{
			if (ModelState.IsValid)
			{
				if (upload != null && upload.ContentLength > 0)
				{
					// Validation content length 
					if (upload.FileName.EndsWith(".csv") || upload.FileName.EndsWith(".CSV"))
					{
						//extention validation 
						ViewBag.Result = "Correct File Uploaded";
					}
				}
			}
			return View();
		}
