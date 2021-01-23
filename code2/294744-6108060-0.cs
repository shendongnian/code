    public static void DownloadFile(string fname, bool forceDownload)
    {
        string path = fname;
        if (fname.StartsWith("~"))
            path = Server.MapPath(fname);
        string name = Path.GetFileName(path);
        string ext = Path.GetExtension(path);
        string type = "";
        // set known types based on file extension  
        if (ext != null)
        {
            switch (ext.ToLower())
            {
                case ".htm":
                case ".html":
                    type = "text/HTML";
                    break;
    
                case ".txt":
                    type = "text/plain";
                    break;
    
                case ".pdf":
                    type = "Application/pdf";
                    break;
    
                case ".doc":
                case ".rtf":
                    type = "Application/msword";
                    break;
    
                case ".exe":
                    type = "application/octet-stream";
                    break;
    
                case ".zip":
                    type = "application/zip";
                    break;
            }
        }
        if (forceDownload)
        {
            Response.AppendHeader("content-disposition",
                "attachment; filename=" + name);
        }
        if (!string.IsNullOrEmpty(type))
            Response.ContentType = type;
        Response.WriteFile(path);
        Response.End();
    }
