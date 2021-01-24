    [HttpPost]
    public ActionResult index(Model model, string RequestList)
    {
        var thelist = System.Web.Helpers.Json.Decode<List<string>>(RequestList);
        thelist.Add(model.TheAttrForAddition);
        //model.TheAttrForAddition is the attribute in the model the user is editing
        
        ViewBag.RequestList= thelist;
        //do other things and return the view
    }
