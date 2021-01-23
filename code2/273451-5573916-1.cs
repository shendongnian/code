    ListView listview = value as ListView;
    double width = listview.Width;
    GridView gv = listview.View as GridView;
    for (int i = 0; i < gv.Columns.Count; i++)
    {
      if (!Double.IsNaN(gv.Columns[i].Width))
          width -= gv.Columns[i].Width;
     }
     return width -5;// this is to take care of margin/padding
