    StringReader sr = new StringReader("<a><b>26a83f12c782</b><c>128</c><d>12</d></a>");
    string b = null;
    double c = 0;
    double d = 0;
    using (XmlReader xmlReader = XmlReader.Create(sr, new XmlReaderSettings() { IgnoreWhitespace = true }))
    {
        xmlReader.MoveToContent();
        xmlReader.ReadStartElement("a", "");
        b = xmlReader.ReadElementContentAsString("b", "");
        c = xmlReader.ReadElementContentAsDouble("c", "");
        d = xmlReader.ReadElementContentAsDouble("d", "");
    }
