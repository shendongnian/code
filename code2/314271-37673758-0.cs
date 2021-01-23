        private Image CreatePreviewImage()
        {
            Image ReportImage = new Image();
            Uri path = new Uri(@"C:\Folder\Image1.png");
            if (File.Exists(path.OriginalString))
            {
                ReportImage.Name = "Report1";
                ReportImage.Source = LoadImageFromFile(path);
            }
            return ReportImage;
        }
        public ImageSource LoadImageFromFile(Uri path)
        {
            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();
            bitmap.UriSource = path;
            bitmap.CacheOption = BitmapCacheOption.OnLoad;
            bitmap.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
            bitmap.DecodePixelWidth = 900;
            bitmap.EndInit();
            bitmap.Freeze(); //This is the magic line that releases/unlocks the file.
            return bitmap;
        }
