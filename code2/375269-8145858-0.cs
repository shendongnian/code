            var xml = XElement.Parse(input);
            var result = new XElement("root",
                from p in xml.Elements("node")
                select new XElement("item", 
                            new XElement("name", new XAttribute("content", p.Attribute("name").Value)),
                            new XElement("value", new XAttribute("content", p.Attribute("value").Value))));
            result.Descendants("item").ToList().ForEach(n => n.ReplaceWith(n.Descendants()));
