	using(var client = new HttpClient())
	{
		client.BaseAddress = new Uri("https://eauction.ccmc.gov.in");
		
		var initial = await client.GetAsync("/frm_scduled_items.aspx");
		
		var initialContent = await initial.Content.ReadAsStringAsync();
		
		var htmlDoc = new HtmlDocument();
		
		htmlDoc.LoadHtml(initialContent);
		
		var viewState = htmlDoc.DocumentNode.SelectSingleNode("//input[@id='__VIEWSTATE']").GetAttributeValue("value", string.Empty);
		var eventValidation = htmlDoc.DocumentNode.SelectSingleNode("//input[@id='__EVENTVALIDATION']").GetAttributeValue("value", string.Empty);
		var content = new FormUrlEncodedContent(new Dictionary<string, string>{
			{"__VIEWSTATE", viewState},
			{"__EVENTVALIDATION", eventValidation},
			{"ctl00$ContentPlaceHolder1$drp_auction_date", "17/02/2016"}
		});
		
		var res = await client.PostAsync("/frm_scduled_items.aspx", content);
		
		var resContent = await res.Content.ReadAsStringAsync();
		
		Console.WriteLine(resContent);
	}
