    RadioDataTemplate = TemplateGenerator.CreateDataTemplate(() =>
    {
        var grid = new Grid();
        grid.Height = 40;
        var textblock = new TextBlock();
        textblock.SetBinding(TextBlock.TextProperty, "Name");
        textblock.Margin = new Thickness(6);
        textblock.TextTrimming = TextTrimming.CharacterEllipsis;
        textblock.HorizontalAlignment = HorizontalAlignment.Left;
        textblock.VerticalAlignment = VerticalAlignment.Center;
        grid.Children.Add(textblock);
        return grid;
    });
