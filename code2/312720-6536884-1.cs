    [HttpPost]
    public ActionResult ChangeName(string name, MyModel model)
    {
        try
        {
            model.ChangeName();
            return JSONSuccess();
        }
        catch (ModelUpdateException)
        {
            return JSONFail();
        }
    }
