            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            // It won't add schemas without XmlUrlResolver
            settings.Schemas.XmlResolver = new XmlUrlResolver();
            // Optional namespace
            var namespace = null;
            settings.Schemas.Add(namespace, "absolutePath.xsd");
            
            using (XmlReader reader = XmlReader.Create(sourcePath, settings))
            {
                XmlDocument document= new XmlDocument();
                document.Load(reader);
                //...
            }
