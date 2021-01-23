    [HttpPost]
    public ActionResult Index(TestViewModel model)
    {
        var ser = new System.Web.Script.Serialization.JavascriptSerializer();
        Dictionary<string, string> dictionary = ser.Deserialize<Dictionary<string, string>>(model.dictionary);
        // Do something with the dictionary
    }
