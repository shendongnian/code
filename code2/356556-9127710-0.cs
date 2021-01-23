    Image displayImage = new Image();
    BitmapImage sourceImage = new BitmapImage();
    sourceImage.BeginInit();
    sourceImage.UriSource = new Uri("pack://application:,,,/Resources/Images/Application.ico");
    sourceImage.EndInit();
    displayImage.Source = sourceImage;
    //set the size you want
    displayImage.Width = 96;
    displayImage.Stretch = Stretch.Uniform;
    
    
