    string result;
    using (StringWriter sw = new StringWriter()) {
    dataTable.WriteXml(sw);
    result = sw.ToString();
    }
    
    If you don't actually need a string but read-only, processable XML, it's a
    better idea to use MemoryStream and XPathDocument:
    
    XPathDocument result;
    using (MemoryStream ms = new MemoryStream()) {
    dataTable.WriteXml(ms);
    ms.Position = 0;
    result = new XPathDocument(ms);
    }
