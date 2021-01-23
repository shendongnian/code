    protected void sgrAssignedRequests_ItemDataBound(object sender, GridViewEditEventArgs e)
    {
      if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
      {
        var hpl = (HyperLink)e.FindControl("hplink");
        // set values here
      }
    }
