    public ActionResult Create()
    {
        var model = new MyViewModel();
        if(something){
            var modelToo = new MyViewModelToo();
            return View(modelToo);
        }
        return View(model);
    }
