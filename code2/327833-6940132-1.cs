    		private void ScrollToElement(String elemName)
		{
			if (webBrowser1.Document != null)
			{
				HtmlDocument doc = webBrowser1.Document;
                HtmlElementCollection elems = doc.All.GetElementsByName(elemName);
                if (elems != null && elems.Count > 0) 
				{
                    HtmlElement elem = elems[0];
                    elem.ScrollIntoView(true);
				}
			}
		}
