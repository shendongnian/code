    private static bool ThumbnailCallback()
    {
        return false;
    }
    
    static void Main(string[] args)
    {
        var blueImage = Image.FromFile("blue.jpg").GetThumbnailImage(1, 1, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        var blueBitmap = new Bitmap(blueImage);
        var blueHue = blueBitmap.GetPixel(0, 0).GetHue();
        var greenImage = Image.FromFile("green.jpg").GetThumbnailImage(1, 1, new Image.GetThumbnailImageAbort(ThumbnailCallback), IntPtr.Zero);
        var greenBitmap = new Bitmap(greenImage);
        var greenHue = greenBitmap.GetPixel(0, 0).GetHue();
    }
