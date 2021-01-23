    Bitmap bmp = new Bitmap("SomeImage");
    
                // Lock the bitmap's bits.  
                Rectangle rect = new Rectangle(0, 0, bmp.Width, bmp.Height);
                BitmapData bmpData = bmp.LockBits(rect, ImageLockMode.ReadWrite, PixelFormat.Format24bppRgb);
    
                // Get the address of the first line.
                IntPtr ptr = bmpData.Scan0;
    
                // Declare an array to hold the bytes of the bitmap.
                int bytes = bmpData.Stride * bmp.Height;
                byte[] rgbValues = new byte[bytes];
                byte[] r = new byte[bytes / 3];
                byte[] g = new byte[bytes / 3];
                byte[] b = new byte[bytes / 3];
    
                // Copy the RGB values into the array.
                Marshal.Copy(ptr, rgbValues, 0, bytes);
    
                int count = 0;
                int stride = bmpData.Stride;
    
                for (int coulmn = 0; coulmn < bmpData.Height; coulmn++)
                {
                    for (int row = 0; row < bmpData.Width; row++)
                    {
                        b[count] = (byte)(rgbValues[(coulmn * stride) + (row * 3)] > 128 ? 1 : 0);
                        g[count] = (byte)(rgbValues[(coulmn * stride) + (row * 3) + 1] > 128 ? 1 : 0);
                        r[count++] = (byte)(rgbValues[(coulmn * stride) + (row * 3) + 2] > 128 ? 1 : 0);
                    }
                }
