    private void _placeSingleColorColumn(Grid grid, Color color, int height, int colNum, int maxHeight)
    {
        Brush brush = new SolidColorBrush(color);
        Rectangle rect = new Rectangle();
        rect.Fill = brush;
        Grid.SetColumn(rect, colNum);
        Grid.SetRow(rect, maxHeight - height);
        Grid.SetRowSpan(rect, height);
        grid.Children.Add(rect);
    }
    private void _createLabels(Grid grid, string[] labels)
    {
        RowDefinition rowDefnLabels = new RowDefinition();
        grid.RowDefinitions.Add(rowDefnLabels);
        for (int i = 0; i < labels.Length; i++)
        {
            TextBlock block = new TextBlock();
            block.Text = labels[i];
            block.HorizontalAlignment = System.Windows.HorizontalAlignment.Center;
            Grid.SetColumn(block, i);
            Grid.SetRow(block, grid.RowDefinitions.Count);
            grid.Children.Add(block);
        }
    }
