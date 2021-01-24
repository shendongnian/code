    [HttpPost]
    public ActionResult LegalLabels(FormCollection form)
    {
        StringBuilder sb = new StringBuilder();
        foreach (var key in form.AllKeys)
        {
            sb.AppendLine(string.Format("Key: {0}. Value: {1}.<br>", key, form[key]));
        }
        ViewBag.FormData = sb.ToString();
        return View();
    }
