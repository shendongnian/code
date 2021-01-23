    public ActionResult Index()
    {
        var encoding = Encoding.GetEncoding("iso-8859-1");
        var data = encoding.GetBytes("éåæÉà;some other value");
        return File(data, "application/csv", "PersonalMessages.csv");
    }
