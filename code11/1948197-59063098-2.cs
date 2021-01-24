    public ActionResult Index()
    {   
        var oRoles = new Roles();
        oRoles.modules.Add("Page-Profile", new List<string>{"Edit","View","Delete"});
        oRoles.modules.Add("user", new List<string>{"Edit","View","Delete","Update"});
        // Not sure why you are serializing to json. 
        // you can directly return View(oRoles) or PartialView(oRoles)
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(oRoles);
        return View(json);
    }
