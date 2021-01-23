    public ActionResult Index()
    {
        return View( new Form1Model() ); // default view
    }
    
    [HttpPost]
    public JsonResult Form1(Form1PostModel model)
    {
        ReturnModel returnModel = SomeAction(model);
        return JsonResult(returnModel);
    }
