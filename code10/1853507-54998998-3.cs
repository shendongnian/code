    [HttpPost]
    public ActionResult PassTheValue(TheModel model) //Pass the entire model
    {
        var theSelectedValue = model.SelectedValue;
        ...
    }
