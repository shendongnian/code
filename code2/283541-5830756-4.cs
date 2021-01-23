    public ActionResult CheckExtension(string file)
    {
        var extension = Path.GetExtension(file ?? string.Empty);
        var validExtensions = new[] { ".xls", ".xlsx" };
        var isValid = validExtensions.Contains(extension, StringComparer.OrdinalIgnoreCase);
        return Json(isValid, JsonRequestBehavior.AllowGet);
    }
