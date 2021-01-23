    public FileStreamResult Index()
    {
        HttpContext.Response.AddHeader("test", "val");
        var file = System.IO.File.Open(Server.MapPath("~/Web.config"), FileMode.Open);
        HttpContext.Response.AddHeader("Content-Length", file.Length.ToString());
        return File(file, "text", "Web.config");
    }
