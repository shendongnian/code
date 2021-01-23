    if (e.Item.ItemType = ListItemType.Item)
    {
      photo p = (photo)e.DataItem;
      Textbox txtTime = (Textbox)e.Item.FindControl("txtTime");
    
      txtTime.text = (p.Time == null ? "" : ((DateTime)p.Time).ToString("dd/MM/yyyy HH:mm:ss"));
    }
