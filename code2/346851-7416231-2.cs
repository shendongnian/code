    ListItemCollection lstr = new ListItemCollection();
    lstr.Add("123");
    lstr .Add("1234");
    foreach (ListItem lst in lstr)
    {
    if (DropDownList1.Items.Contains(lst))
    {
    for (int i = 0; i < DropDownList1.Items.Count; i++)
    {
      if (DropDownList1.Items[i].Equals(lst))
      {
        DropDownList1.Items[i].Attributes.Add("style", "background-color: red;");
      }
     }
     }
     }
