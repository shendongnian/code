        public void DownloadFile(string fileName)
        {
            Response.Clear();
            Response.ContentType = @"application\octet-stream";
            System.IO.FileInfo file = new System.IO.FileInfo(Server.MapPath(FileName));
            Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
            Response.AddHeader("Content-Length", file.Length.ToString());
            Response.ContentType = "application/octet-stream";
            Response.WriteFile(file.FullName);
            Response.Flush();
        }
