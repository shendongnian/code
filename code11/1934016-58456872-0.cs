    public static void test() {
        XmlDocument rssXmlDoc = new XmlDocument();
        // Load the RSS file from the RSS URL
        rssXmlDoc.Load("https://agency.governmentjobs.com/jobfeed.cfm?agency=ocso");
        // Setup name space
        XmlNamespaceManager nsmgr = new XmlNamespaceManager(rssXmlDoc.NameTable);
        nsmgr.AddNamespace("joblisting", "http://www.neogov.com/namespaces/JobListing");
        // Parse the Items in the RSS file
        XmlNodeList rssNodes = rssXmlDoc.SelectNodes("rss/channel/item");
        // Iterate through the items in the RSS file
        foreach (XmlNode rssNode in rssNodes) {
            var xmlnode = rssNode.SelectSingleNode("guid ");
            System.Console.WriteLine("the value of guid is =>" + xmlnode.InnerText);
            XmlNode rssSubNode = rssNode.SelectSingleNode("title");
            string title = rssSubNode != null ? rssSubNode.InnerText : "";
        }
    }
