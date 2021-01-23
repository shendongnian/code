    XmlWriterSettings settings = new XmlWriterSettings();
    settings.Indent = true;
    settings.OmitXmlDeclaration = false;
    using( XmlWriter xw = XmlWriter.Create(Response.Output, settings) )
    {
        xw.WriteStartDocument();
        // Write the root node
        xw.WriteStartElement("Library");
        // Write the books and the book elements
        xw.WriteStartElement("Book");
        xw.WriteStartAttribute("BookType");
        xw.WriteString("Hardback");
        xw.WriteEndAttribute();
        xw.WriteStartElement("Title");
        xw.WriteString("Door Number Three");
        xw.WriteEndElement();
        xw.WriteStartElement("Author");
        xw.WriteString("O'Leary, Patrick");
        xw.WriteEndElement();
        xw.WriteEndElement();
        xw.WriteEndElement();
        // Close the document
        xw.WriteEndDocument();
    }
