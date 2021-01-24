            XmlDocument Doc = new XmlDocument();
            Doc.Load(@"yourpath.xml");
            XmlNodeList xmlNodelist = Doc.DocumentElement.ChildNodes;
            foreach (XmlNode node in xmlNodelist)
            {
                if(node.InnerText.Length > ONEMEGABYTE)
                {
                    node.InnerText = "new value";
                }
            }
            Doc.Save(@"yourpath.xml"); //will replace new changes in the source file.
