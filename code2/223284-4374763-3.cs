    public ActionResult Index()
    {
        var data = Encoding.UTF8.GetBytes("éåæÉà;some other value");
        var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        return File(result, "application/csv;charset=utf-8", "PersonalMessages.csv");
    }
