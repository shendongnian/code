            StringWriter stringWriter = new StringWriter();
            XmlTextWriter xmltextWriter = new XmlTextWriter(stringWriter) {Formatting = Formatting.Indented};
            // Start document
            xmltextWriter.WriteStartDocument();
            xmltextWriter.WriteStartElement("ROOT");
            foreach (PublishedPage page in publishedPages)
            {
                //Create a page element
                xmltextWriter.WriteStartElement("Page");
                xmltextWriter.WriteAttributeString("Action", page.Action);
                xmltextWriter.WriteAttributeString("SearchableProperties", page.SearchableProperties);
                xmltextWriter.WriteEndElement();
            }
            // Same for the other lists 
            // End document
            xmltextWriter.WriteEndElement();
            xmltextWriter.Flush();
            xmltextWriter.Close();
            stringWriter.Flush();
