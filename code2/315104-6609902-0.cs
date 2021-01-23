    // get the screen handle and size
    Screen s = UIHelper.getScreenHandle();
    Size sz = s.Bounds.Size;
    
    // capture the screen
    IntPtr hSrce = CreateDC(null, s.DeviceName, null, IntPtr.Zero);
    IntPtr hDest = CreateCompatibleDC(hSrce);
    IntPtr hBmp = CreateCompatibleBitmap(hSrce, sz.Width, sz.Height);
    IntPtr hOldBmp = SelectObject(hDest, hBmp);
    bool b = BitBlt(hDest, 0, 0, sz.Width, sz.Height, hSrce, 0, 0, CopyPixelOperation.SourceCopy | CopyPixelOperation.CaptureBlt);
    Bitmap bm = Bitmap.FromHbitmap(hBmp);
    SelectObject(hDest, hOldBmp);
    
    // convert the Bitmap to BitmapSource
    IntPtr hBitmap = bm.GetHbitmap();
    
    // Dispose bms if it holds content, Garbage Collector will do the cleaning
    if (bms != null) bms = null;
    
    // create BitmapSource from Bitmap
    bms = System.Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
        hBitmap,
        IntPtr.Zero,
        Int32Rect.Empty,
        System.Windows.Media.Imaging.BitmapSizeOptions.FromEmptyOptions());
    
    // tidy up
    
    // CloseHandle throws SEHException using Framework 4
    // CloseHandle(hBitmap);
    
    DeleteObject(hBitmap);
    hBitmap = IntPtr.Zero;
    
    DeleteObject(hBmp);
    DeleteDC(hDest);
    DeleteDC(hSrce);
    
    bm.Dispose();
    GC.Collect();
