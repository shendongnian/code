    [DllImport("gdi32.dll", EntryPoint = "DeleteObject")]
    [return: MarshalAs(UnmanagedType.Bool)]
    public static extern bool DeleteObject([In] IntPtr hObject);
    public static System.Windows.Media.ImageSource ToImageSource(this Bitmap bitmap)
    {
        System.Windows.Media.ImageSource image;
        IntPtr handle = bitmap.GetHbitmap();
        try
        {
            image = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(handle, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
            image.Freeze();
        }
        finally
        {
           DeleteObject(handle);
        }
        return image;
    }
