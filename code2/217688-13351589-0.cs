    private static void CreateXMLFile(string xml, string filePath)
        {
            // Create the XmlDocument.
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml); //Your string here
            // Save the document to a file and auto-indent the output.
            XmlTextWriter writer = new XmlTextWriter(filePath, null);
            writer.Formatting = Formatting.Indented;
            doc.Save(writer);
        }
