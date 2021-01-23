    private void TextBox_MouseDoubleClick(object sender, MouseButtonEventArgs e)
    {
        grid.RowDefinitions.Add(new RowDefinition());
        for (int i = 0; i < grid.ColumnDefinitions.Count; i++)
        {
            Random r = new Random();
            Label l = new Label { Content = r.Next(10, 1000000000).ToString() };
            grid.Children.Add(l);
            Grid.SetRow(l, grid.RowDefinitions.Count - 1);
            Grid.SetColumn(l, i);
        }
        BindingExpression be = label.GetBindingExpression(Label.ContentProperty);
        be.UpdateTarget();
    }
