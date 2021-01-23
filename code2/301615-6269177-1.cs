    protected void rep_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
          if (e.Item.ItemType == ListItemType.AlternatingItem || e.Item.ItemType == ListItemType.Item)
          {
               var lbDelete = (LinkButton)e.Item.FindControl("lbDelete");
               lbDelete.CommandArgument = retailItem.Id.ToString();
        }
    }
    protected void rpt_ItemCommand(object source, RepeaterCommandEventArgs e) 
    {
       if (e.CommandName == "delete")
            {
                LinkButton btn = e.CommandSource as LinkButton;
                if (btn != null)
                {
                    var itemID = (string)e.CommandArgument;
                    //Do Stuff
                }
            }
    }
