    //array is a byte[]
     using (var memoryStream = new System.IO.MemoryStream(array))
        {
        var image = new BitmapImage();
        image.BeginInit();
        image.CacheOption = BitmapCacheOption.OnLoad; 
        image.StreamSource = memoryStream ;
        image.EndInit();
        
       }
