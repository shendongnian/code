    public ModelWithListOfViewModels model { get; set; }
    
    [HttpGet()]
    public ActionResult FillList()
    {
        model = new ModelWithListOfViewModels();
        //Here you fill the list with the ViewModels you want to pass to the View
        model.ViewModels.Add(/** ViewModel here **/);
        return View("CreateTree", model);
    }
