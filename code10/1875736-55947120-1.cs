    private void Listview_ItemAppearing(object sender, ItemVisibilityEventArgs e)
    {
        //throw new NotImplementedException();
        if (isLoading || Items.Count == 0)
            return;
    
        //hit bottom!
        if (e.Item.ToString() == Items[Items.Count - 1])
        {
            LoadItems();
        }
    }
