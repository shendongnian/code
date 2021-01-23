        public void SetPixels(Bitmap image)
        {
            byte[] array = Pixels;
            var data = image.LockBits(new Rectangle(0, 0, image.Width, image.Height), System.Drawing.Imaging.ImageLockMode.ReadOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
            Parallel.For(0, data.Height, new Action<int>(i =>
            {
                byte tmp;
                int pixel4bpp, pixelPerbpp;
                pixelPerbpp = data.Stride / data.Width;
                for (pixel4bpp = 0; pixel4bpp < data.Stride; pixel4bpp += pixelPerbpp)
                {
                    tmp = (byte)((
       Marshal.ReadByte(data.Scan0, 0 + (data.Stride * i) + pixel4bpp)
     + Marshal.ReadByte(data.Scan0, 1 + (data.Stride * i) + pixel4bpp)
     + Marshal.ReadByte(data.Scan0, 2 + (data.Stride * i) + pixel4bpp)
     + Marshal.ReadByte(data.Scan0, 3 + (data.Stride * i) + pixel4bpp)
     ) / pixelPerbpp);
                    array[i * data.Width + (pixel4bpp / pixelPerbpp)] = tmp;
                }
            }));
            image.UnlockBits(data);
        }
