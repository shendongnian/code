    public void BtnDownload_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "text/plain";
        Response.AppendHeader("Content-Disposition", "attachment; filename=foo.txt");
        Response.Write("some text contents that will be sent to the user");
    }
