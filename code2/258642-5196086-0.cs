    void YourGridview_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        if (e.Row.RowType == DataControlRowType.DataRow)
        {
            // if this is a SqlDataSource you can use DataRowView, 
            // otherwise use whatever type is used in the data source
            DataRowView rowView = (DataRowView)e.Row.DataItem;
            if (!String.IsNullOrEmpty(rowView["ColumnA"])) 
                YourGridview.Columns[0].Visible = true;
            // repeat for your other columns
        }
    }
