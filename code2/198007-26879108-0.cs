     TestImage.Source = GetImage("/Content/Images/test.png")
    
    private static BitmapImage GetImage(string imageUri)
            {
                var bitmapImage = new BitmapImage();
                bitmapImage.BeginInit();
                bitmapImage.UriSource = new Uri("pack://siteoforigin:,,,/" + imageUri,             UriKind.RelativeOrAbsolute);
                bitmapImage.EndInit();
                return bitmapImage;
            } 
