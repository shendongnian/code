	private void Browser_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
	{
		var webBrowser = (WebBrowser)sender;
		if (webBrowser.Document != null)
		{
			foreach (HtmlElement tag in webBrowser.Document.All)
			{
				if (tag.Id == null)
				{
					tag.Id = String.Empty;
					switch (tag.TagName.ToUpper())
					{
						case "A":
						{
							tag.MouseUp += new HtmlElementEventHandler(link_MouseUp);
							break;
						}
					}
				}
			}
		}
	}
	private void link_MouseUp(object sender, HtmlElementEventArgs e)
	{
		var link = (HtmlElement)sender;
		mshtml.HTMLAnchorElementClass a = (mshtml.HTMLAnchorElementClass)link.DomElement;
		switch (e.MouseButtonsPressed)
		{
			case MouseButtons.Left:
			{
				if ((a.target != null && a.target.ToLower() == "_blank") || e.ShiftKeyPressed || e.MouseButtonsPressed == MouseButtons.Middle)
				{
					AddTab(a.href);
				}
				else
				{
					CurrentBrowser.TryNavigate(a.href);
				}
				break;
			}
			case MouseButtons.Right:
			{
				CurrentBrowser.ContextMenuStrip = null;
				var contextTag = new ContextTag();
				contextTag.Element = a;
				contextHtmlLink.Tag = contextTag;
				contextHtmlLink.Show(Cursor.Position);
				break;
			}
		}
	}
