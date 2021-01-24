    private void AddLineButton_Click(object sender, RoutedEventArgs e)
    {
        Create_line();
    }
    List<StackPanel> items;
    private void Create_line()
    {
        RowDefinition gridRow = new RowDefinition();
        gridRow.Height = new GridLength(1, GridUnitType.Star);
        beGrid.RowDefinitions.Add(gridRow);
        StackPanel stack = new StackPanel();
        stack.Orientation = Orientation.Horizontal;
        int i = items.Count + 1;
        TextBlock textBlock = new TextBlock();
        textBlock.Text = "Question";
        textBlock.Name = "Test" + i.ToString();
        stack.Children.Add(textBlock);
        beGrid.Children.Add(stack);
        Grid.SetRow(stack, items.Count);
        items.Add(stack);
    }
