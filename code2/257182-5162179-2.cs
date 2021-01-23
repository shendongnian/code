	XmlNamespaceManager xnm = new XmlNamespaceManager(new NameTable());
	xnm.AddNamespace("thr", "");
	xnm.AddNamespace("feedburner", "");
	XmlParserContext xpc = new XmlParserContext(null, xnm, null, XmlSpace.None);
	XmlTextReader xtr = new XmlTextReader(sResult, XmlNodeType.Element, xpc);
	XElement xmlRssItems = XElement.Load(xtr);
	var result = from rssItem in xmlRssItems.Element("channel").Elements("item")
		select new PodcastItem
		{
			Title = (string)rssItem.Element("title"),
			MyUrl = new Uri(rssItem.Element("enclosure").Attribute("url").Value),
			Total = (string)rssItem.Element("total"),
			OriginalEnclosureLink = (string)rssItem.Element("origEnclosureLink")
		};
	Console.WriteLine("{0}", result);
