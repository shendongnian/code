    ImageData GetImageDataFromImage(Image image)
    {
        using (var bitmap = new Bitmap(image))
        {
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var bytes = new byte[data.Height * data.Stride];
            Marshal.Copy(data.Scan0, bytes, 0, bytes.Length);
            bitmap.UnlockBits(data);
            return new ImageData
            {
                Width = bitmap.Width,
                Height = bitmap.Height,
                PixelFormat = bitmap.PixelFormat,
                PixelData = bytes
            };
        }
    }
