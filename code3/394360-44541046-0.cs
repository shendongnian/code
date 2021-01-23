    protected void DataList2_ItemDataBound(object sender, DataListItemEventArgs e)
    {
        if ((e.Item.ItemType == ListItemType.Item) || 
                 (e.Item.ItemType == ListItemType.AlternatingItem))
        {
            // get inner datalist
            DataList dl3 = e.Item.FindControl("DataList3") as DataList;
            
            // bind inner datalist with data source
            dl3.DataSource = dt; // DataTable that contains binding data
            dl3.DataBind();
        }
    }
