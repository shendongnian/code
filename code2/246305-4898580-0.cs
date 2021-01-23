    HttpContext.Current.Response.ClearContent();
    HttpContext.Current.Response.Clear();
    HttpContext.Current.Response.AddHeader("Content-Disposition", "inline; filename=" + "test.zip");
    HttpContext.Current.Response.ContentType = "application/zip";
    HttpContext.Current.Response.BinaryWrite(ba);
    HttpContext.Current.Response.End();
