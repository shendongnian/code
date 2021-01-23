            string fileName = "XmlOuputTest1.xml";
            string attValue = "Line1.\r\nLine2.";
            string elementValue = "Line1.\r\nLine2.\r\nLine3.";
            XmlWriterSettings xws = new XmlWriterSettings();
            xws.NewLineHandling = NewLineHandling.Entitize;
            XDocument doc = new XDocument(
                new XElement("root",
                    new XAttribute("test", attValue),
                    elementValue));
            using (XmlWriter xw = XmlWriter.Create(fileName, xws))
            {
                doc.Save(xw);
            }
            doc = XDocument.Load(fileName);
            Console.WriteLine("att value: {0}; element value: {1}.",
                attValue == doc.Root.Attribute("test").Value,
                elementValue == doc.Root.Value);
