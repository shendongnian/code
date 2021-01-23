    using(DirectoryEntry de = new DirectoryEntry("IIS://Localhost/w3svc/1/root" + DOCUMENT_PATH))
    {
        filePath = de.Properties["Path"].Value;
    }
    if (!File.Exists(filePath))
            return;
    var fileInfo = new System.IO.FileInfo(filePath);
    Response.ContentType = "application/octet-stream";
    Response.AddHeader("Content-Disposition", String.Format("attachment;filename=\"{0}\"", filePath));
    Response.AddHeader("Content-Length", fileInfo.Length.ToString());
    Response.WriteFile(filePath);
    Response.End();
