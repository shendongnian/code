    public static void SaveToMediaLibrary(
    FrameworkElement element, 
    string title)
    {
    try
    {
        var bmp = new WriteableBitmap(element, null);
        var ms = new MemoryStream();
        bmp.SaveJpeg(
            ms,
            (int)element.ActualWidth,
            (int)element.ActualHeight,
            0,
            100);
        ms.Seek(0, SeekOrigin.Begin);
        var lib = new MediaLibrary();
        var filePath = string.Format(title + ".jpg");
        lib.SavePicture(filePath, ms);
        MessageBox.Show(
            "Saved in your media library!",
            "Done",
            MessageBoxButton.OK);
    }
    catch
    {
        MessageBox.Show(
            "There was an error. Please disconnect your phone from the computer before saving.",
            "Cannot save",
            MessageBoxButton.OK);
    }}
