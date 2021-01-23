    <Image Source="{Binding ImageSrc}"/>
    public ImageSource ImageSrc {
      get {
        if (something) {
          return new BitmapImage(new Uri("logo.png"));
        }
        else {
          return new BitmapImage(new Uri("laugh.png"));
        }
      }
    }
