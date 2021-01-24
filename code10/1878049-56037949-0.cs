    var btn = new RadioButton
    {
        Margin = new Thickness(2, 10, 2, 10),
        Height = 100,
        HorizontalAlignment = HorizontalAlignment.Center,
        VerticalAlignment = VerticalAlignment.Top,
        Content = new Image { Source = new BitmapImage(new Uri(picture.PictureLink, UriKind.Relative)) },
        Name = picture.Name.ToString(),
    };
    WP_mainWrapPanel.Children.Add(btn);
    btn.Checked += btn_Checked;
