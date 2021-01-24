		foreach (var productListItem in productListItems)
		{
			Console.WriteLine(productListItem.GetAttributeValue("data-name", ""));
			var tds = productListItem.Descendants("td").ToList();
			var name = tds[0].InnerText;
			var price = tds[1].InnerText;
            // add to Dictionary
			priceData[name] = new PriceInfo
			{
			  Name = name,
			  RawPrice = price
			};
		}
