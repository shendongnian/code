        {
 
            BitmapData bData = bmp.LockBits(new Rectangle(0,0,IMAGE_WIDTH,IMAGE_HEIGHT),
 
                ImageLockMode.ReadOnly,
 
                PixelFormat.Format24bppRgb);
 
            int lineSize = bData.Width * 3;
 
            int byteCount = lineSize * bData.Height;
 
            byte[] bmpBytes = new byte[byteCount];
 
            byte[] tempLine = new byte[lineSize];
 
            int bmpIndex = 0;
 
            IntPtr scan = new IntPtr(bData.Scan0.ToInt32() + (lineSize * (bData.Height-1)));
 
            for (int i = 0; i < bData.Height; i++)
 
            {
 
                Marshal.Copy(scan, tempLine, 0, lineSize);
 
                scan = new IntPtr(scan.ToInt32()-bData.Stride);
 
                tempLine.CopyTo(bmpBytes, bmpIndex);
 
                bmpIndex += lineSize;
 
            }
 
            bmp.UnlockBits(bData);
 
            return bmpBytes;
 
        }
