	private void timer1_Tick(object sender, EventArgs e)
	{
		HtmlElementCollection classButton = webBrowser1.Document.All;
		foreach (HtmlElement element in classButton)
		{
			if (element.GetAttribute("className") == "btn ipb btn-prim sgnBtn")
			{
				element.InvokeMember("click");
			}
		}
		timer1.Stop(); // stop the first timer
		webBrowser1.Navigate("https://www.ebay.com/itm/362735358056");
		timer2.Stop(); // start the item page timer.
	}
	private void timer2_Tick(object sender, EventArgs e)
	{	
        // item page.
		try
		{
			var elem = webBrowser1.Document.GetElementById("atl_btn_lnk");
			if(elem!=null) // check if element exist.
			{
				elem.InvokeMember("click");
				timer2.Stop();
			}
		}
		catch(Exception e)
		{
		
		}
	}
