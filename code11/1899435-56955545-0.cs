    public ImageSource ImageTicket
    {
        get
        {
            return new BitmapImage(new Uri(ImageSource, UriKind.RelativeOrAbsolute));
        }
    }
