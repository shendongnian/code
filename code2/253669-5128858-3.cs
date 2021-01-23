	internal protected GetErrorUrlForItem(Item item)
	{
		if (Service.IsDuplicateItem(item))
		{
			return BuildItemUrl(item, 
                                "This item already exists");
		}
		return null;
	}
	private void CheckForItemDuplication(Item item)
	{
		var result = GetErrorUrlForItem(item);
		if (result != null)
		{
			View.RedirectWithNotification(result);
		}
	}
