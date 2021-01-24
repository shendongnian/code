            XmlDocument xdoc = new XmlDocument();
            xdoc.Load(@"The path");
            XmlNodeList xnodes = xdoc.SelectSingleNode("/configuration/connectionStrings").ChildNodes;
            foreach (XmlNode item in xnodes)
            {
                if (item.Attributes[0].Value == "ConnectionString")
                {
                    Console.WriteLine(item.Attributes[1].Value);
                }
            }
