    Uri dir = new Uri("red_flag.png", UriKind.Relative);
    ImageSource source = new System.Windows.Media.Imaging.BitmapImage(dir);
    Image image = new Image();
    sur.Source = source;
    StackPanel stack = new StackPanel();
    stack.Children.Add(image);
    myButton.Content = stack;
