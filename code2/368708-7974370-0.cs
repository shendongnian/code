	public static List<string> GetTextSegments(this HtmlNode node)
	{
		string nodesText = ... // get the nodes text
		yield nodesText;
		List<HtmlNode> innerNodes = ... // get the list of inner nodes with a 
		// query like node.SelectNodes("//innerNodes")
		foreach(HtmlNode iNode in innerNodes)
 		{
 			string iNodeText = ... // get iNodes text
 			yield iNodeText;
 		}
	}
