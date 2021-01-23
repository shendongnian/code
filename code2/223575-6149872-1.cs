    try
    {
        IntPtr intPtrHBitmap = IntPtr.Zero; 
        BitmapSource _Source = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(intPtrHBitmap, IntPtr.Zero, System.Windows.Int32Rect.Empty, System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
    finally
    {
        DeleteObject(intPtrHBitmap);
        _Source = null;
    }
