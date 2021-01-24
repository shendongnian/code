    BitmapData bitmapData = this.Bitmap.LockBits(
                new Rectangle(0, 0, this.Bitmap.Width, this.Bitmap.Height),
                ImageLockMode.ReadWrite,
                this.Bitmap.PixelFormat);
            int pixels = bitmapData.Stride * this.Bitmap.Height;
            byte[] bytes = new byte[pixels];
            Marshal.Copy(bitmapData.Scan0, bytes, 0, pixels);
            this.Bitmap.UnlockBits(bitmapData);
            this.Bytes = bytes;
