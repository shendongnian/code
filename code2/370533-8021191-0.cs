    this.Context.Response.ClearContent();
    this.Context.Response.ClearHeaders();
    this.Context.Response.ContentType = "application/pdf";
    this.Context.Response.AddHeader("Content-Disposition", "inline; filename=mytest.pdf");
    this.Context.Response.TransmitFile(sLocalFileName);
    this.Context.Response.Flush();
