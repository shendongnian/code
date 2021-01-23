    public myObject GetMyObject()
    {
        myRepository db = new myRepository();
        return db.ListAllStuff();
    }
    public JsonResult GetMyJSON()
    {
        return Json(GetMyObject(), JsonRequestBehavior.AllowGet);
    }
    public List<SelectList> GetMyEnumerable()
    {
        return this.GetMyObject().ToList();
    }
