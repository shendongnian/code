    protected void dtlPromoEvents_ItemDataBound(object sender, DataListItemEventArgs e)
        {
    
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Retrieve the Hyperlink control in the current DataListItem.
                HyperLink eLink = (HyperLink)e.Item.FindControl("eventLink");
    
                // Check if a URL exists, if not then hide the control
                if (string.IsNullOrEmpty(eLink.NavigateUrl))
                {
                    eLink.Visible =false;
                }
    
            }
        }
