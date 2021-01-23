    public ActionResult Index()
    {
        object i = new List<WebServiceMethod>();
        i = svcService.populateList("Programs");
    
        if (someCondition)
            return View(i);
        else
            return View("AjaxGetServiceData"); // or whatever you called your view.aspx
    }
