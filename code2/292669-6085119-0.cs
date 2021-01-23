    public object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture) 
    {
        var file = value as System.IO.FileInfo;
        if (MediaResourceFactory.IsImage(file.Extension)) {
            System.Windows.Media.Imaging.BitmapImage image = new System.Windows.Media.Imaging.BitmapImage();
            image.SetSource(file.OpenRead());
            return image;
        }
        else if (MediaResourceFactory.IsVideo(file.Extension)) {
           // create source for MediaElement
           return new Uri(file.FullName).AbsoluteUri;
        }
        return null;
    }
