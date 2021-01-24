    queryString1 = " and position IN( ";
    List<string> selected = new List<string>();
      foreach (ListItem li in PositionList.Items)
    {
        if (li.Selected == true)
        { 
         selected.Add( PositionList.SelectedItem);
        }
    }
     // values in comma
     queryString1+=string.Join(",", selected.Select(x => $"'{x}'"))
      queryString1+=")";
 
