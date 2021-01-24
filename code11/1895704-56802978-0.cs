    private void gv_PricingList_RowValidating(object sender, RowValidatingEventArgs e)
    {
        if (e.Row is GridViewNewRowInfo)
        {
            //...
        }
        else if (e.Row is GridViewDataRowInfo)
        {
            //...
        }
        else if (e.Row is GridViewFilteringRowInfo)
        {
            //...
        }
    }
