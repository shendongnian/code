		private delegate bool FindFilter(MailItem item);
		private static bool FindAssignedItemsOnly(MailItem itm)
		{
			MailItem mi = itm as MailItem;
			if (mi == null) return false;
			return (mi.StateInd.Code == StateInd.ASSIGNED); 
		}
		private List<MailItem> Find<T_Item, T_Adaptor>(T_Adaptor adaptor, MailItemId MailId, FindFilter filter)
    {
			List<T_Item> tempList = ((List<T_Item>)(typeof(T_Adaptor).InvokeMember(
					"Load",
					BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.InvokeMethod,
					null, adaptor,
					new Object[] { null, MailId, null })));
			totalItemsFound = tempList.Count;
			List<T_Item> Items = tempList.FindAll(delegate(T_Item itm) 
														{ 
															if (filter == null) 
																return true; 
															return filter(itm as MailItem); 
														});
        List<MailItem> mailItems = new List<MailItem>();
        foreach (T_Item itm in Items)
            mailItems.Add(itm as MailItem);
        return mailItems;
    }
    public List<MailItem> FindItems(MailItemId itemId, string mailCategoryCd)
    {
        List<MailItem> mailItems = new List<MailItem>();
        switch (mailCategoryCd)
        {
            case EXPRESS:
					mailItems = Find<ExpressItem, ExpressItemAdapter>(new ExpressItemAdapter(), itemId, FindAssignedItemsOnly);
                break;
            case PARCELS:
					mailItems = Find<Parcel, ParcelAdapter>(new ParcelAdapter(), itemId, FindAssignedItemsOnly);
                break;
            case LETTERS:
					mailItems = Find<Letter, LetterAdapter>(new LetterAdapter(), itemId, FindAssignedItemsOnly);
                break;
        }
        return mailItems;
    }
