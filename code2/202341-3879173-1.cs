    foreach (ListItem item in cblList.Items)
    {
       if (item.Value == "2")
       {
          item.Attributes.Add("style", "display:none");
       }
    }
