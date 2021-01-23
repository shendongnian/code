    string docText = null;
    byte[] byteArray = null;
    using (WordprocessingDocument wordDoc = WordprocessingDocument.Open(documentPath, true))
    {
        using (StreamReader sr = new StreamReader(wordDoc.MainDocumentPart.GetStream()))
        {
            docText = sr.ReadToEnd();  // <-- converts byte[] stream to string
        }
        // Play with the XML
        XmlDocument xml = new XmlDocument();
        xml.LoadXml(docText);  // the string contains the XML of the Word document
        XmlNodeList nodes = xml.GetElementsByTagName("w:body");
        XmlNode chiefBodyNode = nodes[0];
        // add paragraphs with AppendChild... 
        // remove a node by getting a ChildNode and doing chiefBodyNode.RemoveChild[i] ...
        // Or play with the string form
        docText = docText.Replace("John","Joe");
        // If you manipulated the XML, write it back to the string
        //docText = xml.OuterXml;  // comment out the line above if XML edits are all you want to do, and uncomment out this line
         // Save the file - yes, back to the file system - required
         using (StreamWriter sw = new StreamWriter(wordDoc.MainDocumentPart.GetStream(FileMode.Create)))
         {                    
            sw.Write(docText);
         }
     }
     // Read it back in as bytes
     byteArray = File.ReadAllBytes(documentPath); // new bytes, ready for DB saving
