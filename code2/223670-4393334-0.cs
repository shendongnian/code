    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //Check for a data row
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            //Find the checkbox control by ID and set it.
            ((CheckBox)e.Row.FindControl("CheckBoxId")).Checked = IsItemChecked(((DataRowView)e.Row.DataItem)[0]);
        } 
    }
