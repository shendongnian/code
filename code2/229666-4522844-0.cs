    context.Response.AddHeader(
        "Content-Disposition", 
        String.Format("attachment; filename={0}", fileName));
    context.Response.ContentType = contentType;
    context.Response.AddHeader(
        "Content-Length", 
        new FileInfo(fullPath).Length.ToString());
