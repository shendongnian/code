    protected void downloadpdf_Click(object sender, EventArgs e)
    {
        Response.Clear();
        Response.ContentType = "application/octet-stream";
        Response.AddHeader("Content-Disposition", "attachment; filename="downloadName.pdf");
        Response.WriteFile(Server.MapPath(@"~/path of pdf/actualfile.pdf"));
        Response.End();
    }
