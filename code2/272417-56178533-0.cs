    DataGridTextColumn colNameStatus = new DataGridTextColumn();
    colNameStatus2.Header = "Status";
    colNameStatus2.MinWidth = 100;
    colNameStatus2.Binding = new Binding("Status");
    grdYourGrid.Columns.Add(colNameStatus);
    Style style = new Style(typeof(TextBlock));
    Trigger tri = new Trigger() { Property = TextBlock.TextProperty, Value = "Running" };
    tri.Setters.Add(new Setter() { Property = TextBlock.BackgroundProperty, Value = Brushes.Green });
    style.Triggers.Add(tri);
