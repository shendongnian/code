    bool defaultAssigned = false;
    Image image = new Image();
    image.ImageFailed += (s, args) =>
    {
       if (!defaultAssigned)
       {
           image.Source = new BitmapImage(defaultImageUri);
           bDefaultAssigned = true;
       }
    }
    image.Source = new BitmapImage(sampleImageUri);
