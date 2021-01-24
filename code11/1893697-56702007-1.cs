    public static ImageSource ToImageSource()
    {
         Bitmap bitmap = Properties.Resources.Image;
         IntPtr hBitmap = bitmap.GetHbitmap();
            
         ImageSource wpfBitmap = Imaging.CreateBitmapSourceFromHBitmap(
                            hBitmap,
                            IntPtr.Zero,
                            new Int32Rect(0, 0, bitmap.Width, bitmap.Height),
                            BitmapSizeOptions.FromEmptyOptions());
        
          DeleteObject(hBitmap);
          return wpfBitmap;
    }
    
    [System.Runtime.InteropServices.DllImport("gdi32.dll")]
    public static extern bool DeleteObject(IntPtr hObject);
