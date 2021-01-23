    private void Files_List_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        using (var store = IsolatedStorageFile.GetUserStoreForApplication())
        {
            if (store.FileExists(Path.Combine("wallpaper", Files_List.SelectedValue.ToString())))
            {
                using (var isoStream = store.OpenFile(Path.Combine("wallpaper", Files_List.SelectedValue.ToString()), FileMode.Open))
                {
                    BitmapImage b = new BitmapImage();
                    b.SetSource(isoStream);
                    someImage.Source = b;
                }
            }
        }
    }
