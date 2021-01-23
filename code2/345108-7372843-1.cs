    // serialize an object to XML string
    public string ToXml<_type>(_type itm)
    {
        XmlSerializer ser = new XmlSerializer(itm.GetType());
        StringWriter sw = new StringWriter();
        ser.Serialize(sw, itm);
        return sw.ToString();
    }
    public _type FromXml<_type>(string str)
    {
        XmlSerializer ser = new XmlSerializer(itm.GetType());
        return (_type)ser.Deserialize(new StringReader(xml));
    }
