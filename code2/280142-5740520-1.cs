    public ActionResult Index()
    {
        return View();
    }
     
    [HttpPost]
    public ActionResult Index(FormCollection[] form)
    {
        for (int fileIndex = 0; fileIndex < Request.Files.Count; fileIndex++)
        {
            //let upload file to App_Data folder
            Request.Files[fileIndex].SaveAs(Server.MapPath("/App_Data/" + Request.Files[fileIndex].FileName));
        }
        return View();
    }
