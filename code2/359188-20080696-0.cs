    if (file.Name == fileName)
    
    {
         Response.ClearContent();
         Response.AddHeader("Content-Disposition", "attachment; filename=" + file.Name);
         Response.AddHeader("Content-Length", file.Length.ToString());
         Response.TransmitFile(file.FullName);
         //Response.End(); Will raise that error. this works well locally but not with IIS
         Response.Flush();//Won't get error with Flush() so use this Instead of End()
    
    
    }
