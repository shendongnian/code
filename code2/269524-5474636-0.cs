    protected void SomeName_ItemBound(Object sender, DataGridItemEventArgs e) 
    {
         // Use the ItemDataBound event to customize the DataGrid control. 
         // The ItemDataBound event allows you to access the data before 
         // the item is displayed in the control. In this example, the 
         // ItemDataBound event is used to format the items in the 
         // CurrencyColumn in currency format.
         if((e.Item.ItemType == ListItemType.Item) || 
             (e.Item.ItemType == ListItemType.AlternatingItem))
         {
             // e.Item // is your current row
             e.Item.Visible = false;
         }
    }
