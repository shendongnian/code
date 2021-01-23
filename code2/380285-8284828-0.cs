    public ActionResult Download(string id, string name)
    {
        var file = Server.MapPath("~/Content/uploads/" + id);
        return File(file, "application/octet-stream", name);
    }
