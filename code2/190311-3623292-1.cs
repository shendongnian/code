            int vid = 2;
            var doc = new XmlDocument();
            doc.LoadXml("<Equipment><Items><SubItems  vid=\"1\" name=\"Foo\"/><SubItems vid=\"2\" name=\"Bar\"/></Items></Equipment>");
            var nav = doc.CreateNavigator();
            foreach (XPathNavigator it in nav.Select("/Equipment/Items/SubItems"))
            {
                if(it.MoveToAttribute("vid", it.NamespaceURI)) {
                    int vidFromXML = int.Parse(it.Value);                    
                    if (vidFromXML == vid)
                    {
                        // if(it.MoveToNextAttribute() ... or be more explicit like the following:
                       
                        if (it.MoveToParent() && it.MoveToAttribute("name", it.NamespaceURI))
                        {
                            it.SetValue("Two");
                        } else {
                            throw new XmlException("The name attribute was not found.");
                        }                
                    }
                } else {
                        throw new XmlException("The vid attribute was not found.");
                }
            }
