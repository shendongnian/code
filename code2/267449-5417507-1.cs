    public void MakeWin(DependencyObject owner)
    {
       MakeWin(Window.GetWindow(owner));
    }
    
    public void MakeWin(Window owner)
    {
       Window window = new Window();
       Grid grid = new Grid();
       grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(50) });
       grid.ColumnDefinitions.Add(new ColumnDefinition {Width = GridLength.Auto});
       window.Content = grid;
    
       Label label = new Label { Content = "Hello World!" };
       Grid.SetColumn(label, 0); // Depandency property
       grid.Children.Add(label);
    
       window.Owner = owner;
       window.ShowDialog();
    }
