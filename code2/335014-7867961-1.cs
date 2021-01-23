    private readonly System.Collections.Generic.Dictionary<string, ImageSource> typeIcons = new Dictionary<string, ImageSource>();
    
    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
            this.typeIcons.Add("winhdd", new BitmapImage(new Uri("Images/Icons/winhdd.png", UriKind.Relative)));
            this.typeIcons.Add("harddrive", new BitmapImage(new Uri("Images/Icons/hdd.png", UriKind.Relative)));
            this.typeIcons.Add("removable", new BitmapImage(new Uri("Images/Icons/removablehdd.png", UriKind.Relative)));
            this.typeIcons.Add("folder", new BitmapImage(new Uri("Images/Icons/folder.png", UriKind.Relative)));
    }
