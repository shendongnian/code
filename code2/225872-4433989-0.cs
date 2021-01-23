    XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"D:\Test.xml");
            XmlElement xmlElement = xdoc.DocumentElement;
            foreach (XmlNode node in xmlElement.ChildNodes)
                if (node.NodeType == XmlNodeType.Text
                    && !string.IsNullOrWhiteSpace(node.Value))
                    Console.WriteLine(node.Value.Trim());
