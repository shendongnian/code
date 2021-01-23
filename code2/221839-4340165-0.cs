        static void ProcessXmlFile()
        {
            XNamespace ns = "http://tempuri.org/KeyEmFileSchema.xsd/";
            
            // load the xml document
            XElement settings = XElement.Load("data.xml");
            // shift ALL elements in the settings document into the target namespace
            foreach (XElement e in settings.DescendantsAndSelf())
            {
                e.Name = ns + e.Name.LocalName;
            }
                        
            // write the output document
            var file = new XDocument(new XElement(ns + "foo",
                                            settings));
            Console.Write(file.ToString());            
        }
