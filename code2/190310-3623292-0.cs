            int vid = 2;
            var doc = new XmlDocument();
            doc.LoadXml("<Equipment><Items><SubItems name=\"1\"/><SubItems name=\"2\"/></Items></Equipment>");
            var nav = doc.CreateNavigator();
            foreach (XPathNavigator it in nav.Select("/Equipment/Items/SubItems"))
            {
                if(it.MoveToAttribute("name", it.NamespaceURI)) {
                    var name = it.Value;
                    int vidFromXML = int.Parse(name);
                    if (vidFromXML == vid)
                    {
                        it.SetValue("Two");
                    }
                } else {
                        throw new XmlException("The name attribute was not found.");
                }
            }
    
            Console.WriteLine(doc.OuterXml);
