    public static BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
    {
    	MemoryStream ms = new MemoryStream();
    	bitmap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
    	BitmapImage bImg = new System.Windows.Media.Imaging.BitmapImage();
    
    	bImg.BeginInit();
    	bImg.StreamSource = new MemoryStream(ms.ToArray());
    	bImg.CreateOptions = BitmapCreateOptions.None;
    	bImg.CacheOption = BitmapCacheOption.Default;
    	bImg.EndInit();
    
    	ms.Close();
    
    	return bImg;
    }
