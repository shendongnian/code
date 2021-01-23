    [HttpPost]
    public ActionResult MyAction(string dictionary)
    {
    	var s = new System.Web.Script.Serialization.JavaScriptSerializer();
    	Dictionary<string, string[]> d = s.Deserialize<Dictionary<string, string[]>>(dictionary);
    	return View();
    }
