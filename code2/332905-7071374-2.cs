    public static List<XDocument> GetResources(string startURL)
    {
        List<XDocument> ret = new List<XDocument>();
        GetResourcesRecursive(startURL, ret);
        return ret;
    }
    private static void GetResourcesRecursive(string startURL,
                                              List<XDocument> result)
    {
        var doc = XDocument.Parse(GetXml(startURL));
        var xs = new XmlSerializer(typeof(resourceList));
        var rdr = doc.CreateReader();
        if (xs.CanDeserialize(rdr))
        {
            var rl = (resourceList)xs.Deserialize(doc.CreateReader());
    
            foreach (var item in rl.resourceURL)
            {
                GetResourcesRecursive(startURL + item.location, ref result);
            }
        }
        else
        {
            result.Add(doc);
        }
    }
