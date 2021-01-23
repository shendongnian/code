    public static List<XDocument> GetResources(string startURL)
    {
        var result = new List<XDocument>();
        var doc = XDocument.Parse(GetXml(startURL));
        var xs = new XmlSerializer(typeof(resourceList));
        var rdr = doc.CreateReader();
        if (xs.CanDeserialize(rdr))
        {
            var rl = (resourceList)xs.Deserialize(doc.CreateReader());
    
            foreach (var item in rl.resourceURL)
            {
                result.AddRange(GetResources(startURL + item.location));
            }
        }
        else
        {
            result.Add(doc);
        }
        return result;
    }
