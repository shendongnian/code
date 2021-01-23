	private void CheckForItemDuplication(Item item)
	{
		if (Service.IsDuplicateItem(item))
		{
			View.RedirectWithNotification(BuildItemUrl(item), 
                           "This item already exists");
		}
	}
