    void CustomersGridView_RowDataBound(Object sender, GridViewRowEventArgs e)
    {    
        if(e.Row.RowType == DataControlRowType.DataRow)
        {
            CheckBox checkbox = (CheckBox)e.Row.FindControl("chkRows");
            checkbox.Enabled = e.Row.Cells["nameOfCellWithLabel"].Text == "Validated";
        }
    }
