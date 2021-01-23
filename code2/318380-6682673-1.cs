    protected void DataGrid1_ItemDataBound(object sender, DataGridItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var status = Convert.ToBoolean(((DataRowView)e.Item.DataItem).Row.ItemArray[1]);
            if (!status)
            {
                e.Item.Cells[1].BackColor = System.Drawing.Color.Red;
            }
        }
    }
