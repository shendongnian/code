            XDocument xdoc = XDocument.Load(xmlFile);
            Dictionary<string, string> nodelist = new Dictionary<string, string>();
            nodelist.Add("entry", "entry");
            foreach (XElement element in xdoc.Element("entry").Descendants())
            {
                if (!nodelist.ContainsKey(element.Name.ToString()))
                    nodelist.Add(element.Name.ToString(),
                        (nodelist.ContainsKey(element.Parent.Name.ToString())? nodelist[element.Parent.Name.ToString()] : element.Parent.Name.ToString())+"."+ element.Name.ToString());
                if (!element.HasElements)
                {
                    Console.WriteLine($"{ nodelist[element.Parent.Name.ToString()]}.{element.Name}");
                }               
            }
