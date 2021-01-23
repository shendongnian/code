    protected void Button_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.AppendHeader("Content-Disposition", "attachment; filename=test.txt");
        Response.ContentType = "text/plain";
        Response.Write("some text");
    }
