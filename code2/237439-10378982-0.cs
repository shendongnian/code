    public ActionResult Index()
    {
        object i = new List<WebServiceMethod>();       
        i = svcService.populateList("Programs");       
        if (Request.IsAjaxRequest == "True")
        {
            return Json(i, JsonRequestBehavior.AllowGet);           
        }
        else
        {
            return View(i)
        }
    }
