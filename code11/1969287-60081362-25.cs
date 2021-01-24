    Image CreateImageFromImageData(ImageData imageData)
    {
        var bitmap = new Bitmap(imageData.Width, imageData.Height, imageData.PixelFormat);
        var data = bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height),
            ImageLockMode.ReadWrite, bitmap.PixelFormat);
        var bytes = new byte[data.Height * data.Stride];
        Marshal.Copy(imageData.PixelData, 0, data.Scan0, imageData.PixelData.Length);
        bitmap.UnlockBits(data);
        return bitmap;
    }
