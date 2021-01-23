    HtmlElementCollection spans = WebBrowser1.Document.GetElementsByTagName("span");
    for (i = 0; i < spans.Count; i++) {
    	HtmlElement span = spans(i);
    	if (span.GetAttribute("customAttr") == "customAttrValue") {
    		string onclick = span.GetAttribute("onclick");
    		WebBrowser1.Document.InvokeScript(onclick);
    	}
    }
