foreach (SettingsProperty currentProperty in Properties.Settings.Default.Properties)
{
    TextBox X               = new TextBox();
    TextBox Y               = new TextBox();
    Grid G                  = new Grid();
    ColumnDefinition one    = new ColumnDefinition();
    ColumnDefinition two    = new ColumnDefinition();
    one.Width               = new GridLength(50, GridUnitType.Star);
    two.Width               = new GridLength(50, GridUnitType.Star);
    G.ColumnDefinitions.Add(one);
    G.ColumnDefinitions.Add(two);
    Grid.SetColumn(X, 0);
    Grid.SetColumn(Y, 1);
    X.SetBinding(TextBox.TextProperty,
        new Binding
        {
            Source = currentProperty.Name,
            Path = new PropertyPath("."),
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        });
    Y.SetBinding(TextBox.TextProperty,
        new Binding
        {
            Source = currentProperty.DefaultValue,
            Path = new PropertyPath("."),
            UpdateSourceTrigger = UpdateSourceTrigger.PropertyChanged
        });
    G.Children.Add(X);
    G.Children.Add(Y);
    MyStackPanel.Children.Add(G);
}
