    MyGrid.RowDefinitions = new RowDefinitionCollection();
    MyGrid.ColumnDefinitions = new ColumnDefinitionCollection();
    for (int MyCount = 0; MyCount < 5; MyCount++) 
    {
      MyGrid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1,  GridUnitType.Star) });  
       MyGrid.ColumnDefinitions.Add(new ColumnDefinition { Width = new G    GridLength(1,    GridUnitType.Star) });
    }
