    public static List<XDocument> GetResources(string startURL)
    {
        List<XDocument> ret = new List<XDocument>();
        Queue<string> urls = new Queue<string>();
        urls.Enqueue(startUrl);
        while (urls.Count > 0)
        {
            string url = urls.Dequeue();
            var doc = XDocument.Parse(GetXml(url));
            var xs = new XmlSerializer(typeof(resourceList));
            var rdr = doc.CreateReader();
            if (xs.CanDeserialize(rdr))
            {
                var rl = (resourceList) xs.Deserialize(doc.CreateReader());
               foreach (var item in rl.resourceURL)
               {
                   queue.Enqueue(url + item.location);
               }
            }
            else
            {
                ret.Add(doc);
            }  
        }
        return ret;
    }
