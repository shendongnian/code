    public void ProcessRequest(HttpContext context)
    {
        context.Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", attachment.FileName));
        context.Response.AddHeader("Content-Length", attachment.Fileblob.Length.ToString());
        context.Response.ContentType = GetMimeType(attachment.FileName);
        context.Response.OutputStream.Write(attachment.Fileblob, 0, attachment.Fileblob.Length);
    }
