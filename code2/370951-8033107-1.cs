    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem) {
            
                ((Label)e.Item.FindControl("dlLbl")).Text= ((SPListItem)e.Item.DataItem)["Project Title"].ToString();
    
          }
