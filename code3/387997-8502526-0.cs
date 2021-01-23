    protected void LVP_ItemDataBound(object sender, ListViewItemEventArgs e)
    {
        if (e.Item.ItemType == ListViewItemType.DataItem)
        {
            Label EmpIDLabel = (Label)e.Item.FindControl("EmpIDLabel");
 
            System.Data.DataRowView rowView = e.Item.DataItem as System.Data.DataRowView;
            EmpIDLabel.Text = rowView["EmpID"].ToString();
        }
    }
