    MyGrid.RowDefinitions = new RowDefinitionCollection();
    MyGrid.ColumnDefinitions = new ColumnDefinitionCollection();
    for (int i = 0; i< 5; i++) 
    {
      MyGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1,  GridUnitType.Star) });  
       MyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new G    GridLength(1,    GridUnitType.Star) });
    }
