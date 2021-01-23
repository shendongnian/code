     protected void RadGrid_OnItemDataBound(object sender, Telerik.Web.UI.GridItemEventArgs e)
        {
            if (e.Item is GridDataItem)
            {
                GridDataItem dataItem = e.Item as GridDataItem;
                var test = DataBinder.Eval(dataItem.DataItem, "Column").ToString();                
            }
        }
