    protected void RadGrid1_ItemCommand(object sender, Telerik.Web.UI.GridCommandEventArgs e)
    {
       if (e.CommandName == "dosomething")
        {
            //Use a line of code here to save that User_ID that you want from the first column
            theUserId = e.Item.OwnerTableView.DataKeyValues[e.Item.ItemIndex]["User_ID"];
        }
    }
