    public ActionResult GetFields()
    {
    var model=new MyModel();
    model.Selections =(from m in database.table select m.Field1).ToList();
    return View(model);
    }
    
    public ActionResult GetComments(string field1)
    {
    return Content((from c in database.table where(c.Field1==field1)select c.Comments).First());
    }
    
    [HttpPost]
    public void SaveComments(string field1, string comments)
    {
    var record=(from r in database.table where(r.Field1==field1)select r).First();
    record.Comments=comments;
    database.SaveChanges;
    return;
    }
