    protected void Application_BeginRequest(Object sender, EventArgs e)
    {
        if (Request.RawUrl== "/someShorturl/page.aspx")
        {
            HttpContext.Current.RewritePath("/ExternalDocuments/ExternalDocumentUpload.aspx?hjgbasdjfjsggfsdf");
        }
    }
