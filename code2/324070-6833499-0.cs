    public ActionResult MyActionButton(FormCollection collection)
    {
        string value = collection["MyList"];
        return View();
    }
