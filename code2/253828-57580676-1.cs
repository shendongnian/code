	using (var textWriter = File.CreateText("test.txt")) 
	using (XhtmlTextWriter writer = new XhtmlTextWriter(textWriter)) {
		
		writer.RenderBeginTag(HtmlTextWriterTag.Html);
		  writer.RenderBeginTag(HtmlTextWriterTag.Head);
		    writer.RenderBeginTag(HtmlTextWriterTag.Title);
		      writer.Write("My Title");
		    writer.myRenderEndTag(); // Title
		  writer.myRenderEndTag(); // Head
		  writer.RenderBeginTag(HtmlTextWriterTag.Body);
		  writer.myRenderEndTag(); // Body
		writer.myRenderEndTag(); // Html
		
	}
