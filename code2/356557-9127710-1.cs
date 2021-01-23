    Image displayImage = new Image();
    // Create the source
    BitmapImage sourceImage = new BitmapImage();
    sourceImage.BeginInit();
    sourceImage.UriSource = new Uri("pack://application:,,,/Resources/Images/Application.ico");
    sourceImage.EndInit();
    // Set the source
    displayImage.Source = sourceImage;
    // Set the size you want
    displayImage.Width = 96;
    displayImage.Stretch = Stretch.Uniform;
    
    
