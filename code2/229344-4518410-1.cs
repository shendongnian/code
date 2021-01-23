    ColumnDefinition c = new ColumnDefinition();
    c.Width = new GridLength(50, GridUnitType.Pixel);
    
    ColumnDefinition c1 = new ColumnDefinition();
    c1.Width = new GridLength(100, GridUnitType.Pixel);
    
    ColumnDefinition c2 = new ColumnDefinition();
    c2.Width = new GridLength(0, GridUnitType.Star);
    
    grMain.ColumnDefinitions.Add(c);
    grMain.ColumnDefinitions.Add(c1);
    grMain.ColumnDefinitions.Add(c2);
