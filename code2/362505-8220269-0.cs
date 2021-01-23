    foreach (XmlNode node in entries)
	{
		var content = node.SelectSingleNode("at:content", ns).InnerText;
		
		if(!content.ToLower().Contains("@somename"))
		{
			sb.Append(String.Format("<li><span>{2}:</span> <a href=\"{0}\">{1}</a></li>", node.ChildNodes[2].Attributes["href"].Value, node.ChildNodes[3].InnerText, node.LastChild.FirstChild.InnerText.Split(' ')[0]));
		}
	}
