    private void LoadFromIsostore_Click(object sender, RoutedEventArgs e)
    {
        using (IsolatedStorageFile file = IsolatedStorageFile.GetUserStoreForApplication())
        {
            using (IsolatedStorageFileStream fs = file.OpenFile("saved.image", FileMode.Open))
            {
                MyPhotoClass c = new MyPhotoClass();
                BitmapSource picture = c.ConvertToBitmapSource(fs);
                MyPicture.Source = picture;
            }
        }
    }
