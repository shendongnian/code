    [WebMethod]
    public dsXmlSummary getXML()
    {
        TextReader reader = new StringReader("<dsXmlSummary><FirstName>Mark</FirstName></dsXmlSummary>");
        dsXmlSummary ds = (dsXmlSummary)serializer.Deserialize(reader);
        reader.Close();
    }
