    Response.ClearContent();    
    Response.ClearHeaders();    
    Response.ContentType = "application/octet-stream";                            
    Response.AppendHeader("Content-Disposition", "attachment; filename=\"" + fileName + "\";");    
    Response.OutputStream.Write(data, 0, data.Length);    
    Response.End();    
