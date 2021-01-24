    ImageData GetImageDataFromImage(Image image)
    {
        using (var bitmap = new Bitmap(image.Width, image.Height, image.PixelFormat))
        {
            using (var g = Graphics.FromImage(bitmap))
                g.DrawImage(image, new Rectangle(0, 0, image.Width, image.Height));
            var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                ImageLockMode.ReadOnly, bitmap.PixelFormat);
            var rowLength = image.Width * Image.GetPixelFormatSize(image.PixelFormat) / 8;
            var bytes = new byte[image.Height * rowLength];
            var ptr = data.Scan0;
            for (var i = 0; i < image.Height; i++)
            {
                Marshal.Copy(ptr, bytes, i * rowLength, rowLength);
                ptr += data.Stride;
            }
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
