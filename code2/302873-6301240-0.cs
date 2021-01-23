                Border b = new Border();
                Grid.SetColumn(b, 0);
                Grid.SetColumnSpan(b, 3);
                Grid.SetRowSpan(b, 3);
    
                b.CornerRadius = new CornerRadius(1);
                b.Background = new SolidColorBrush(Colors.Red);
    
                // Then add your border to the grid
                g.Children.Add(b);
