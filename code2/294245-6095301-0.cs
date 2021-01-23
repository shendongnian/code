    protected void DataList1_ItemDataBound(object sender, DataListItemEventArgs e)
    {
     if ((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem))
        {
           DataRow dr = ((DataRowView)e.Item.DataItem).Row;
           ((CheckBox)e.Item.FindControl("chkOffline")).Checked = Convert.ToBoolean(dr["chkOffline"]);
         }
        }
    }
