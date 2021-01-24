    private void Grid_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        Grid grid = (Grid)sender;
        if (e.NewSize.Width < 200)
        {
            grid.ColumnDefinitions[0].Width = new GridLength(0);
            grid.ColumnDefinitions[2].Width = new GridLength(0);
        }
        else
        {
            grid.ColumnDefinitions[0].Width = new GridLength(10, GridUnitType.Star);
            grid.ColumnDefinitions[2].Width = new GridLength(10, GridUnitType.Star);
        }
    }
