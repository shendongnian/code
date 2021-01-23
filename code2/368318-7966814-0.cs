    public ActionResult Index()
    {
        var csv = "मानक हिन्दी;some other value";
        var data = Encoding.UTF8.GetBytes(csv);
        data = Encoding.UTF8.GetPreamble().Concat(data).ToArray();
        var cd = new ContentDisposition
        {
            Inline = false,
            FileName = "newExcelSheet.csv"
        };
        Response.AddHeader("Content-Disposition", cd.ToString());
        return File(data, "text/csv");
    }
