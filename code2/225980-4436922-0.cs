    public XmlReader GetXMLContent(string path)
    {
        XmlReader responseReader = XmlReader.Create(path);   
        // do something special
        return responseReader;
    }
    using(XmlReader r = this.GetXMLContent("http://sample.xml"))
    {
        // read
    }
