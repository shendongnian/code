            int k = 0, d = 0; //kills and deaths
            var doc = XDocument.Parse(xmlString);
            var elem = doc.XPathSelectElement("/SimpleKD//player[@name='Tardis']");
            if (elem != null)
            {
                var killsNode = (XElement)elem.FirstNode;
                k = int.Parse(killsNode.Value);
                var deathsNode = (XElement)killsNode.NextNode;
                d = int.Parse(deathsNode.Value);
            }
            else
            {
                elem = doc.XPathSelectElement("/SimpleKD");
                elem.Add(new XElement("player",
                                   new XAttribute("name", "Tardis"),
                               new XElement("kills", k),
                               new XElement("deaths", d)));
            }
            xmlString = doc.ToString();
            Console.WriteLine("Kills: {0}", k);
            Console.WriteLine("Deaths: {0}", d);
