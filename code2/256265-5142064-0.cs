    lines[i] = new Rectangle()
    {
        Height = i * scale,
        Width = 10,
        StrokeThickness = 5,
        Stroke = new SolidColorBrush(Colors.Red),
        Name = i.ToString(),
    };
    lines[i].Margin = new Thickness(11 * i, 0, 0, 0);
