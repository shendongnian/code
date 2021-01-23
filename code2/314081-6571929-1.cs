    private void Button_Click(object sender, RoutedEventArgs e)
    {
        Grid grid = null;
        Action action = () =>
        	{
        		var foreground = ((Label)grid.Children[0]).Foreground;
        		MessageBox.Show(foreground.ToString());
        
        		grid.DataContext = new { Color = Brushes.Green };
        
        		foreground = ((Label)grid.Children[0]).Foreground;
        		MessageBox.Show(foreground.ToString());
        	};
        grid = Application.LoadComponent(new Uri("Stuff/GridOne.xaml", UriKind.Relative)) as Grid;
        if (grid.IsLoaded)
        {
        	action();
        }
        else
        {
        	grid.Loaded += (s, _) => action();
        }
        // This adds the grid to some StackPanel, if you do not do something like this
        // nothing will happen since the control will not be loaded and thus the event
        // will not fire, etc. 
        ControlStack.Children.Add(grid);
    }
