    public bool ImageCrop(int X, int Y, int W, int H)
    {     
        Bitmap croppedImage = imageObject.Clone(new Rectangle(X, Y, W, H), imageObject.PixelFormat);
        imageObject.Dispose();
        imageObject = new Bitmap(croppedImage);
        croppedImage.Dispose();
    }
