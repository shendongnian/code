    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/csv";
        Response.AppendHeader("Content-Disposition", "attachment; filename=foo.csv");
        Response.Write("val1,val2,val3");
    }
