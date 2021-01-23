            // Start document
            xmltextWriter.WriteStartDocument();
            xmltextWriter.WriteStartElement("ROOT");
            foreach (PublishedPage page in publishedPages)
            {
                //Create a page element
                xmltextWriter.WriteStartElement("Page");
                xmltextWriter.WriteAttributeString("Action", page.Action);
                xmltextWriter.WriteAttributeString("SearchableProperties", page.SearchableProperties);
