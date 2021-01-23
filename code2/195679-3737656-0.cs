    Response.ClearHeaders();
    Response.ClearContent();
    Response.Buffer = true;
    
    Response.AppendHeader("Content-Disposition", "inline; attachment; filename=Filename.pdf");
    Response.ContentType = "application/pdf";
    Response.WriteFile(path);
    Response.Flush();
    Response.End();
