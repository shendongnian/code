    public ActionResult DownloadFile()
    {
        string filename = "File.pdf";
        string filepath = AppDomain.CurrentDomain.BaseDirectory + "/Path/To/File/" + filename;
        byte[] filedata = System.IO.File.ReadAllBytes(filepath);
        string contentType = MimeMapping.GetMimeMapping(filepath);
        var cd = new System.Net.Mime.ContentDisposition
        {
            FileName = filename,
            Inline = true,
        };
        Response.AppendHeader("Content-Disposition", cd.ToString());
        return File(filedata, contentType);
    }
