    Image CreateImageFromImageData(ImageData imageData)
    {
        var bitmap = new Bitmap(imageData.Width, imageData.Height, imageData.PixelFormat);
        var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, bitmap.PixelFormat);
        var rowLength = imageData.Width * Image.GetPixelFormatSize(imageData.PixelFormat) / 8;
        var bytes = new byte[imageData.Height * rowLength];
        var ptr = data.Scan0;
        for (var i = 0; i < imageData.Height; i++)
        {
            Marshal.Copy(imageData.PixelData, i * rowLength, ptr, rowLength);
            ptr += data.Stride;
        }
        bitmap.UnlockBits(data);
        return bitmap;
    }
