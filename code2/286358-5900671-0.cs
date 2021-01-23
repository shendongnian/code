    private ImageSource getImageFromIsolatedStorage(string imageName)
    {
        BitmapImage bimg = new BitmapImage();
    
        using (IsolatedStorageFile iso = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream stream = iso.OpenFile(imageName, FileMode.Open, FileAccess.Read))
            {
                bimg.SetSource(stream);
            }
        }
        return bimg;
    }
