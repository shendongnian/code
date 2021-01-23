    e.Row.Visible = false;
    protected void gvTenantList_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (null != e.Row.DataItem)
        {
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            if (hsPastDueLeases.Contains((int)rowView["LeaseID"]))
            {
                e.Row.CssClass += " pinkbg";
                e.Row.Visible = !showCurrentOnly;
            }
            else if (showPastDueOnly){ //code to prevent showing this row
                e.Row.Visible = false;
            }
        }
    }
