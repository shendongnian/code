    byte[] imageData = part.Image; // that you get from db
    if (imageData == null || imageData.Length == 0) 
       {
       //Show error msg or return here;
       return;
       }
    
    var image = new BitmapImage();
            
     using (var ms = new System.IO.MemoryStream(imageData))
    {
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad; 
        image.StreamSource = ms;
        image.EndInit();
        image.Freeze();
    }
