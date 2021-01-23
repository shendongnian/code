    // Include, in your class or elsewhere:
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    private static extern bool DeleteObject(IntPtr hObject);
    Bitmap image = LoadYourBitmap();
    IntPtr hbitmap = image.GetHbitmap();
    try
    {
       var bitmapSource = Imaging.CreateBitmapSourceFromHBitmap(
          hbitmap, IntPtr.Zero, Int32Rect.Empty,
          Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
    finally
    {
        // Clean up the bitmap data
        DeleteObject(hbitmap);
    }
