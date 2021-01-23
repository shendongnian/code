    public ActionResult Download()
    {
        var data = Encoding.UTF8.GetBytes("some data");
        var result = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        return File(result, "application/csv", "foo.csv");
    }
