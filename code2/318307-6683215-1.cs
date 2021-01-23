    //Forces Download/Save rather than opening in Browser//
      public static void ForceDownload(string virtualPath, string fileName)
      { 
    
        Response.Clear();
        Response.AddHeader("content-disposition", "attachment; filename=" + fileName);
        Response.WriteFile(virtualPath);
        Response.ContentType = "";
        Response.End(); 
    
      } 
