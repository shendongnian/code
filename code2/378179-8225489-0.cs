    protected void lvData_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Blog blg = (Blog)e.Item.DataItem;
            Label lblDescription = (Label)e.Item.FindControl("lblDescription");
            lblDescription.Text = blg.Description.Substring(0, 50);
        }
    }
