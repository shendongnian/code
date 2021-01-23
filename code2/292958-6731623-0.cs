    //GET
    public ActionResult CreateNewMyEntity()
    {
        MyEntity newMyEntity = new MyEntity();
        newMyEntity._propertyValue = "5";
        return View(newMyEntity);
    }
