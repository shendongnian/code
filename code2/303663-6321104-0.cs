    [HttpPost]
    public ActionResult Index(MyModel model)
    {
        ModelState.Remove("CurrentBegin");
        model.CurrentBegin = DateTime.Parse(form["CurrentBegin"]).AddMonths(3);           
        return Index(model);
    }
