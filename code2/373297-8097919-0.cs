    public void AddColumnHeader(DataGridTextColumn column, string header1, string header2)
    {
        var panel = new StackPanel();
        
        var labelA = new Label();
        labelA.Content = header1;
        panel.Children.Add(labelA);
        
        var separator = new Separator();
        separator.HorizontalAlignment = HorizontalAlignment.Stretch;
        panel.Children.Add(separator);
        
        var labelB = new Label();
        labelB.Content = header2;
        panel.Children.Add(labelA);
    
        column.Header = panel;
    }
