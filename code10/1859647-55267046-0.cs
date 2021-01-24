    [HttpPost]
    [Authorize]
    public ActionResult Search(FormCollection form)
    {
        var fields = new List<(string, string)>();
        foreach (var item in Request.Form)
        {
            fields.Add((item.Key, item.Value));
        }
        // do some other stuff
    }
