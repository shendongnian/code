    public static BitmapSource ConvertBitmap(System.Drawing.Bitmap source)
    { 
        return System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                      source.GetHbitmap(),
                      IntPtr.Zero,
                      Int32Rect.Empty,
                      System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
 
