    //GET
    public ActionResult CreateNewMyEntity(string default_value)
    {
        MyEntity newMyEntity = new MyEntity();
        newMyEntity._propertyValue = default_value;
        return View(newMyEntity);
    }
