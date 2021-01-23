    HtmlElementCollection iframes = WebBrowser1.Document.GetElementsByTagName("iframe");
    HtmlElement iframe = iframes(0 /* iframe index */); // 
    HtmlElementCollection spans = iframe.Document.GetElementsByTagName("span");
    for (i = 0; i < spans.Count; i++) {
    	HtmlElement span = spans(i);
    	if (span.GetAttribute("customAttr") == "customAttrValue") {
    		string onclick = span.Children(0).GetAttribute("onclick"); //span.Children(0) should return the <a>
    		WebBrowser1.Document.InvokeScript(onclick);
    	}
    }
