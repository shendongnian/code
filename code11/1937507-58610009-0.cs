	var content = "<strong>http://www.helloworld.com/test</strong> with a hyperlink <a href=\"www.google.com\">www.google.com</a> and also a normal link www.youtube.com dsdsd sometext http://www.website.com/test sdfsdfsdfg ssdgsdf sdfsdfsdf";
	HtmlAgilityPack.HtmlDocument document = new HtmlAgilityPack.HtmlDocument();
	document.LoadHtml(content);                        
	Regex regex = new Regex(@"(?:http(s)?:\/\/)?[\w.-]+(?:\.[\w\.-]+)+[\w\-\._~:/?#[\]@!\$&'\(\)\*\+,;=.]+", RegexOptions.Compiled);
	FindMatchesInText(document.DocumentNode, regex);       
	private void FindMatchesInText(HtmlNode parentNode, Regex regex)
	{                        
		foreach (var node in parentNode.ChildNodes)
		{                
			var match = regex.Match(node.InnerText);
			while(match.Success)
			{
				Console.WriteLine(match.Value);
				match = match.NextMatch();
			}
			//Recurse
			FindMatchesInText(node, regex);
		}            
	}
