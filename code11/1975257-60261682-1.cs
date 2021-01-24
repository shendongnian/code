        string strFileName = "FileName";//Here you have to set the File Name...
        if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "pdf")
        {
            Response.ContentType = "application/PDF";
        }
        else if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "doc")
        {
            Response.ContentType = "application/msword";
        }
        else if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "docx")
        {
            Response.ContentType = "application/msword";
        }
        else if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "xls")
        {
            Response.ContentType = "application/vnd.ms-excel";
        }
        else if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "xlsx")
        {
            Response.ContentType = "application/vnd.ms-excel";
        }
        else if (strFileName.Substring(strFileName.LastIndexOf('.') + 1).ToLower() == "ppt")
        {
            Response.ContentType = "application/vnd.ms-powerpoint";
        }
        else if (strFileName.Substring(strFileName.IndexOf('.') + 1).ToLower() == "txt")
        {
            Response.ContentType = "text/plain";
        }
        else
        {
            Response.ContentType = "text/plain";
        }
         System.IO.FileInfo file = new System.IO.FileInfo(strFileName);
        
        Response.Clear();
        Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
        Response.AddHeader("Content-Length", file.Length.ToString());
        Response.WriteFile(file.FullName);
        Response.End();
