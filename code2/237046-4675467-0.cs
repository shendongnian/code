    //// Snippet
            int pitch;
            int bytesPerPixel = 4;
            Rectangle lockRectangle = new Rectangle(0, 0, bitmap.Width, bitmap.Height);
            // Lock the bitmap
            GraphicsStream surfacedata = surface.LockRectangle(LockFlags.ReadOnly, out pitch);
            BitmapData bitmapdata = bitmap.LockBits(lockRectangle, ImageLockMode.WriteOnly, PixelFormat.Format32bppRgb);
        
            // Copy surface to bitmap
            for (int scanline = 0; scanline < bitmap.Height; ++scanline)
            {
                byte* dest = (byte*)bitmapdata.Scan0 + (scanline * bitmap.Width * bytesPerPixel);
                byte* source = (byte*)surfacedata.InternalData + (scanline * pitch);
                RtlMoveMemory(new IntPtr(dest), new IntPtr(source), (bitmap.Width * bytesPerPixel));
            }
    ////
