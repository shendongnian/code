  Private Function DsToXML(DataSet ds) as System.Xml.XmlDataDocument
    Dim xmlDoc As System.Xml.XmlDataDocument 
    Dim xmlDec As System.Xml.XmlDeclaration
    Dim xmlWriter As System.Xml.XmlWriter
    xmlWriter = New XmlTextWriter(context.Response.OutputStream,System.Text.Encoding.UTF8)
    xmlDoc = New System.Xml.XmlDataDocument(ds)
    xmlDoc.DataSet.EnforceConstraints = False
    xmlDec = xmlDoc.CreateXmlDeclaration("1.0", "UTF-8", Nothing)
    xmlDoc.PrependChild(xmlDec)
    xmlDoc.WriteTo(xmlWriter)
    Retuen xmlDoc
  End Eunction
