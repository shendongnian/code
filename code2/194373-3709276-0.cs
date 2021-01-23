    Response.ContentType = "Application/pdf";
    
    Response.AppendHeader("content-disposition", "attachment; filename=" + FilePath);
    
    Response.TransmitFile( Server.MapPath(filepath) );
    
    Response.End();
