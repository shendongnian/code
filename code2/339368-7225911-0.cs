    protected void wgrdSearchResult_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "edit")
        {
            int index = Convert.ToInt32(wgrdSearchResult.DataKeys[e.CommandArgument].Value);
            string CustomerID = (string)wgrdSearchResult.DataKeys[e.CommandArgument].Values["CustomerID"];
        }
    }
