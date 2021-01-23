	var doc = new XmlDocument();
	doc.LoadXml(xml);
	var nodes = doc.SelectNodes("Root/Child");
	var arr = nodes
		.OfType<XmlNode>()
		.Select(n =>
			new
			{
				Column1 = n.Attributes["val1"].Value,
				Column2 = n.Attributes["val1"].Value
			})
		.ToArray();
	var result = arr
		.Select(n =>
		new
		{
			Index = Array.IndexOf(arr, n),
			Column1 = n.Column1,
			Column2 = n.Column2,
		});
