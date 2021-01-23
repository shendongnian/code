    public ActionResult Index(int id)
    {
         MyModel model = dataLayer.getModel(id);
         return View(model);
    }
