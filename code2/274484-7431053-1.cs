    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item)
        {
            Label PriceLabel = (Label)e.Item.FindControl("PriceLabel");
            Label SalePrice = (Label)e.Item.FindControl("SalePrice");
            
            //
            // Do you calculations here ..
            //
            SalePrice.Text = "Your Final Value";
        }
    }
