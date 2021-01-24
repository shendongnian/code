	var context = BrowsingContext.New();
	var document = await context.OpenAsync(res => res.Content("foo<div>Outside<p>Inside</p></div>bar"));
	var walker = document.CreateTreeWalker(document.Body, AngleSharp.Dom.FilterSettings.Text);
	
	while (walker.ToNext() != null)
	{
		var current = walker.Current;
		
		// if just whitespace, e.g., formatting line breaks, or in p anyway - skip
		if (
			(current.TextContent.Trim().Length == 0) ||
			(current.ParentElement.LocalName == "p"))
		{
			continue;
		}
		// if next to paragraph perform the normalization
		else if (
			(current.PreviousSibling is IElement previous && previous.LocalName == "p") ||
			(current.NextSibling is IElement next && next.LocalName == "p"))
		{
			var newNode = document.CreateElement("p");
			current.ReplaceWith(newNode);
			newNode.Append(current);
		}
	}
	
	document.Body.ToHtml().Dump();
