    Size size = Image.Size;
    Bitmap bitmap = Image;
    // myPrewrittenBuff is allocated just like myReadingBuffer below (skipped for space sake)
    // But with two differences: the buff would be byte [] (not ushort[]) and the Stride == 3 * size.Width (not 6 * ...) because we build a 24bpp not 48bpp
    BitmapData writerBuff= bm.LockBits(new Rectangle(0, 0, size.Width, size.Height), ImageLockMode.UserInputBuffer | ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb, myPrewrittenBuff);
    // not here writerBuff and myPrewrittenBuff are the same reference
    bitmap.UnlockBits(writerBuff);
    // done. bitmap updated , no marshal needed to copy myPrewrittenBuff 
    // Now lets read back the bitmap into another format...
    BitmapData myReadingBuffer = new BitmapData();
    ushort[] buff = new ushort[(3 * size.Width) * size.Height]; // ;Marshal.AllocHGlobal() if you want
    GCHandle handle= GCHandle.Alloc(buff, GCHandleType.Pinned);
    myReadingBuffer.Scan0 = Marshal.UnsafeAddrOfPinnedArrayElement(buff, 0);
    myReadingBuffer.Height = size.Height;
    myReadingBuffer.Width = size.Width;
    myReadingBuffer.PixelFormat = PixelFormat.Format48bppRgb;
    myReadingBuffer.Stride = 6 * size.Width;
    // now read into that buff
    BitmapData result = bitmap.LockBits(new Rectangle(0, 0, size.Width, size.Height), ImageLockMode.UserInputBuffer | ImageLockMode.ReadOnly, PixelFormat.Format48bppRgb, myReadingBuffer);
    if (object.ReferenceEquals(result, myReadingBuffer)) {
        // Note: we pass here
        // and buff is filled
    }
    bitmap.UnlockBits(result);
    handle.Free();
    // use buff at will...
