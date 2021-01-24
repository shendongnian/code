	private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
	{
		var elements = webBrowser1.Document.GetElementsByTagName("span");
		foreach (HtmlElement element in elements)
		{
			if(string.IsNullOrEmpty(element.InnerText)) 
				continue;
			
			if (element.InnerText.Contains("Tutorial"))
			{
				element.InnerHtml = "<span style='background-color: rgb(255, 255, 0);'> sensor </span>";
			}
		}
	}
