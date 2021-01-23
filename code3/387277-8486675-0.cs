    foreach(RepeaterItem item in ChildRepeater.Items){
      if(item.ItemType == ListItemType.Item || item.ItemType == ListItemType.AlternatingItem){
        var txt = (TextBox)item.FindControl("TextBox1");
      }
    }
