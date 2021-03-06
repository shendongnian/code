    IEnumerable<BusinessObject> ParseWithXPath(string xml)
    {
        XmlDocument doc = new XmlDocument();
        doc.LoadXml(xml);
        foreach (XmlNode node in doc.DocumentElement.SelectNodes("Data/Row")) // XPath query
        {
            yield return new BusinessObject
            {
                Id = Int32.Parse(node.SelectSingleNode("Id").InnerText),
                Name = node.SelectSingleNode("Name").InnerText
            };
        }
    }
