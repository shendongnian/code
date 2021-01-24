    Func<Item, Task<BitmapImage>> f = async (item) =>
    {
        BitmapImage bitmapImage = new BitmapImage();
        StorageFile file = await StorageFile.GetFileFromPathAsync(item.ImagePath);
        using (IRandomAccessStream fileStream = await file.OpenAsync(FileAccessMode.Read))
        {
            await bitmapImage.SetSourceAsync(fileStream);
        }
        return bitmapImage;
    };
    BitmapImage[] bitmapImages = await Task.WhenAll(someList.Select(f).ToArray();
