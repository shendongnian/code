    private void RibbonLoaded(object sender, RoutedEventArgs e)
    {
      DependencyObject groupBorder = VisualTreeHelper.GetChild(Foobar, 0);
      Grid groupMainGrid = VisualTreeHelper.GetChild(groupBorder , 0) as Grid;
      if (groupMainGrid != null)
      {
        groupMainGrid.RowDefinitions[2].MinHeight = 0;
      }
    } 
