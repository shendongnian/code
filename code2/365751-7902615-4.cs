	public ActionResult Index() {
		var contentData = new ContentData();
		contentData.ContentDataA = "Hello";
		contentData.ContentDataB = "World";
		ViewData.Add("contentData", contentData);
	}
