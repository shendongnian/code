    var grid = new Grid();
    grid.Children.Add(new Rectangle() { Stroke = Brushes.Red, Fill = Brushes.Blue });
    grid.Children.Add(new TextBlock() { Text = "some text" });
    panel.Children.Add(grid);
    // or
    panel.Children.Add(new Border()
    {
        BorderBrush = Brushes.Red,
        BorderThickness = new Thickness(1),
        Background = Brushes.Blue,
        Child = new TextBlock() { Text = "some text" },
    });
