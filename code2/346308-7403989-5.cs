    [HttpPost]
    public ActionResult QueryCriteria(FormCollection formCollection)
    {
        var isValid = true;
        foreach (var field in form.Fields)
        {
            var value = (formCollection[field.Name] ?? "").Trim();
            ...
