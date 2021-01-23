      void Item_Bound(Object sender, DataListItemEventArgs e)
      {
    
         if (e.Item.ItemType == ListItemType.Item || 
             e.Item.ItemType == ListItemType.AlternatingItem)
         {
    
            // Retrieve the Hyperlink control in the current DataListItem.
            Hyperlink eLink = (Hyperlink)e.Item.FindControl("eventLink");
    
           // Check if a URL exists, if not then hide the control
           if(String.IsNullOrEmpty(eLink.NavigateURL)){
             eLink.Visible = False;
           }
    
         }
      }
