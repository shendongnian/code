    dataView = oResults.DefaultView;
    // Now, for my binding preparation...
    Binding bindMyColumn = new Binding();
    bindMyColumn.Source = dataView;
    bindMyColumn.Path = new PropertyPath("[0][MyTextColumn]");
    txtMyTextColumn.SetBinding(TextBox.TextProperty, bindMyColumn);
