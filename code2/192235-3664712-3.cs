    [WebMethod]
    public dsXmlSummary getXML()
    {
        dsXmlSummary xml = new dsXmlSummary();
        xml.Items = new YourItemsType[1];    // <-- initialize here
        xml.Items[0] = new YourItemsType();  // <-- initialize first object
        xml.Items[0].nameFirst = "Mark"; //error thrown here: System.NullReferenceException: Object reference not set to an instance of an object.
        xml.Items[0].nameLast = "Twain";
        xml.Items[0].Type = "Writer";
        return xml;
    }
