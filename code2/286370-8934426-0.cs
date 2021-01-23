    string dirpath = System.Configuration.ConfigurationManager.AppSettings["FilePath"];
    string file = System.Configuration.ConfigurationManager.AppSettings["FileName"];
    
    System.IO.FileInfo fi = new System.IO.FileInfo(dirpath + file);
    string contentlen = fi.Length.ToString();
    
    context.Response.Buffer = true;
    context.Response.Clear();
    context.Response.AddHeader("content-disposition", "attachment; filename=" + file);
    context.Response.AddHeader("content-length", contentlen);
    context.Response.ContentType = "application/pdf";
    				
    try
    {
        context.Response.WriteFile(dirpath + file);
    }
    catch (Exception)
    {
        context.Response.Redirect("Error.aspx");
    }
