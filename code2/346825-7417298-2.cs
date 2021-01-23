    protected void DataGrid1_ItemDataBound(object sender, GridItemEventArgs e)
    {
        DropDownList ddl = e.Item.FindControl("DropDownList1") as DropDownList;
        if (ddl != null)
        {
            ddl.SelectedValue = DataBinder.Eval(e.Item.DataItem, "DropDownColumnValue").ToString();
        }
    }
