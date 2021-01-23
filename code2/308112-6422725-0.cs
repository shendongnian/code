    //Create Image element
    Image rotated270 = new Image();
    rotated270.Width = 150;
    //Create source
    BitmapImage bi = new BitmapImage();
    //BitmapImage properties must be in a BeginInit/EndInit block
    bi.BeginInit();
    bi.UriSource = new Uri(@"pack://application:,,/sampleImages/watermelon.jpg");
    //Set image rotation
    bi.Rotation = Rotation.Rotate270;
    bi.EndInit();
    //set image source
    rotated270.Source = bi;
