    private void RadGrid_ItemCreated(object sender, Telerik.Web.UI.GridItemEventArgs e)
    {
        if ((e.Item is GridDataItem)) {
            GridDataItem gridDataItem = (GridDataItem)e.Item;
            MyType dataItem = (MyType)gridDataItem.DataItem;
        }
    }
