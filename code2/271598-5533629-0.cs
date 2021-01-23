    [WebMethod]
    public void StoreItem(TransitionItem tItem)
    {
        IItem item=tItem.ToItem();
        item.Store();
    }
