    XmlSerializer xml = new XmlSerializer(typeof(MessageType));
    XmlDocument xdoc = new XmlDocument();
    xdoc.Load(stream);
    foreach(XmlElement elm in xdoc.GetElementsByTagName("MessageType"))
    {
        MessageType mt = (MessageType)xml.Deserialize(new StringReader(elm.OuterXml)); 
    }
