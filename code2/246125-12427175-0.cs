    [HttpPost]
    public ActionResult Index(FormCollection collection)
    {
         Dictionary<string,object> form = new Dictionary<string, object>();
         collection.CopyTo(form);
         return View();
    }
