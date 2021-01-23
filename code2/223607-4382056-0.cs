    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
    ...
    IntPtr hObject = b.GetHbitmap();
    bs = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
               hObject,
               IntPtr.Zero,
               Int32Rect.Empty,
               options);
    DeleteObject(hObject);
