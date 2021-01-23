    var b = new Border
                {
                    BorderBrush = new SolidColorBrush(Colors.Black),
                    BorderThickness = new Thickness(5)
                };
    var bi = new BitmapImage
                    {
                        UriSource = new Uri("/myimage.png", UriKind.Relative)
                    };
    b.Child = new Image {Source = bi};
    wp.Children.Add(b);
