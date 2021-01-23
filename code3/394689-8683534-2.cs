      var doc =  System.Xml.Linq.XDocument.Load(fileName);       
      Visit(doc.Root);
        private static void Visit(XElement element)
        {
            string name = element.Attribute("name").Value;
            Execute(name);
            // you seem to have just 1 child, this will handle multiple
            // adjust to select only elements with a specific name 
            foreach (var child in element.Elements())
                Visit(child);
        }
        private static void Execute(string name)
        {
            switch (name)
            {
                case "level1A" :
                    // snippet a
                    break;
                // more cases
            }
        }
