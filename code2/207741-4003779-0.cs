    void Repeater_ItemDataBound(Object Sender, RepeaterItemEventArgs e) {
      if (e.Item.ItemType == ListItemType.Item '
        || e.Item.ItemType == ListItemType.AlternatingItem)   
      {
        e.Item.FindControl("myDiv")).Attributes["class"] = "id" + index++;
      }
    }
