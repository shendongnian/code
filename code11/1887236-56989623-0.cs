    public ActionResult Create()
    {
    var nmodel= new MyViewModel().fieldname;
    if(something){
        return View(nmodel);
    }
    return View(model);
    }
