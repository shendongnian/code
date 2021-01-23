    protected void RadGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        if (e.Item.IsInEditMode && e.Item is GridEditableItem)
        {
            if (e.Item.ItemIndex == -1)
            {
                // insert
                GridEditableItem item = e.Item as GridEditableItem;
                
            }
            else
            {
                // edit
                GridEditableItem item = e.Item as GridEditableItem;
                (item["ID"].Controls[0] as TextBox).ReadOnly = true;
            }
        }
    }
