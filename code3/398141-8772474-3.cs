    foreach(RepeaterItem item in ChildRepeater.Items){
      if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem){
        var txt = (TextBox)item.FindControl("MainContent_ParentRepeater_ChildRepeater_0_HB1_0");
      }
    }
