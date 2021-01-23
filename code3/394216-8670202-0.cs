    private BitmapSource BitmaptoBitmapsource(System.Drawing.Bitmap bitmap)
    {
        BitmapSource bms;
        IntPtr hBitmap = bitmap.GetHbitmap();
        BitmapSizeOptions sizeOptions = BitmapSizeOptions.FromEmptyOptions();
        bms = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(hBitmap, 
            IntPtr.Zero, Int32Rect.Empty, sizeOptions);
        bms.Freeze();
        // NEW:
        DeleteObject(hBitmap);
        return bms;
    }
