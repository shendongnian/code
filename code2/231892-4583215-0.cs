    protected void Page_Load(object sender, EventArgs e)
    {
        //.............
        //Going about generating my XML
        //.............
        Response.Clear();
        Response.ContentType = "text/xml";        
        Response.AddHeader("Content-Disposition", "attachment; filename=template.xml");
        Response.Write(xmlDoc.InnerXml);
        Response.End();
    }
