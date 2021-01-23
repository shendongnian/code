    protected void Page_Load(object sender, EventAgrs e)
    {
        using (var reader = new StreamReader(Request.InputStream))
        {
            string xml = reader.ReadToEnd();
            // do something with the XML
        }
    }
