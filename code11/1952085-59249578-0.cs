    ListView list = (ListView)elem;
    GridView gridView = list.View as GridView;
    if (gridView != null)
    {
        foreach (GridViewColumn column in gridView.Columns)
        {
            //...
        }
    }
