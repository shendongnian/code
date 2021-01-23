    // If you bind a list of objects as your data source you can use this to get the
    // index into the list.
    protected void OnCheckedChanged( Object sender, EventArgs e )
    {
        if ( sender is CheckBox )
        {
            // we do this to get the index into the list of the item we want to work with.
            CheckBox     cb = sender as CheckBox;
            GridViewRow gvr = cb.NamingContainer as GridViewRow;
            int dataItemIndex = gvr.DataItemIndex;  // index into your list, regardless of page
            int rowIndex      = gvr.RowIndex;       // row index in gridview.
        }
    }
