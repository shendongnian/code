    private static void ProcessItems(ExchangeService exchangeService)
    {
    	var offset = 0;
    	const int pageSize = 100;
    	
    	FindItemsResults<Item> result;
    	
    	do
    	{
    		var view = new ItemView(pageSize, offset)
    		{
    			SearchFilter = new SearchFilter.IsEqualTo(EmailMessageSchema.IsRead, false)
    		};
    		
    		result = exchangeService.FindItems(WellKnownFolderName.Inbox, view);
    		
    		foreach (var item in result)
    		{
    			ProcessItem(item);
    		}
    		
    		offset += pageSize;
    	} while (result.MoreAvailable);
    }
