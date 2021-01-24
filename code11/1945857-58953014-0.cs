	orderHeader current = null;
	var itemList = new List<orderHeader>();
	foreach (var item in OutboundOrderHeaders)
	{
		if (current == null || current.OutboundNumber != item.OutboundNumber)  // Try to match orderHeader item
		{
			current = new orderHeader()
			{
				OutboundNumber = item.OutboundNumber,
				Status = item.Status
				OrderDate = item.OrderDate
				orderLine = new List<orderLine>()
			};
			
			itemList.Add(current);
		}
		
		current.orderLine.Add(new orderLine()
		{
			OutboundNumber = item.OutboundNumber
			OutboundLine = item.OutboundLine
			Status = item.Status
			StockProduct = item.StockProduct
		});
	}
