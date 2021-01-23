    List<GridDataItem> Items = (from item in rgShipProducts.MasterTableView.Items.Cast<GridDataItem>()
                                    where  ((CheckBox)item.FindControl("chkChangeAddr")).Checked
                                    select item).ToList();
        if (Items.Count > 0)
        {
            string strkey = Items[0].GetDataKeyValue("ID").ToString();
        }
