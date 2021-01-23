    public BitmapImage ThumbImage 
    { 
        get 
        { 
            BitmapImage image = new BitmapImage();                    
            IsolatedStorageFile isoStore = IsolatedStorageFile.GetUserStoreForApplication();
            string isoFilename = "myfileInIsoStore.jpg";
            var stream = isoStore.OpenFile(isoFilename, System.IO.FileMode.Open);
            image.SetSource(stream);
            return image;
        }     
    }
