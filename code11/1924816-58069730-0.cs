    private void ListView_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        ListView listView = sender as ListView;
        GridView gridView = listView.View as GridView;
    
        var width = listView.ActualWidth - SystemParameters.VerticalScrollBarWidth;
    
        var column1 = 0.40;
        var column2 = 0.15;
        var column3 = 0.15;
        var column4 = 0.15;
        var column5 = 0.15;
    
        gridView .Columns[0].Width = width*column1;
        gridView .Columns[1].Width = width*column2;
        gridView .Columns[2].Width = width*column3;
        gridView .Columns[3].Width = width*column4;
        gridView .Columns[4].Width = width*column5;
    }
