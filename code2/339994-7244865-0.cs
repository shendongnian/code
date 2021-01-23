    public void ProcessRequest(HttpContext context)
    {
     context.Response.ContentType = "text/plain";
     string fileName = context.Request.QueryString.Get("fileName");
     FileInfo fileInfo = new FileInfo(Server.MapPath(".") + "/" + fileName);
     context.Response.Write(fileInfo.LastWriteTime.ToString());
    }
