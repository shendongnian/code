    static private Bitmap resizeBitmap(Bitmap inputBitmap, Orientation orientation) {
        return (Bitmap)resizeImage(inputBitmap, orientation);
    }
    //Resizes images
    static private Image resizeImage(Image inputImage, Orientation orientation) {
        double scaleX = 1;
        double scaleY = 1;
        int pageWidth = orientation == Orientation.Portrait ? (int)PageDimensions.Width : (int)PageDimensions.Height;
        int pageHeight = orientation == Orientation.Portrait ? (int)PageDimensions.Height : (int)PageDimensions.Width;
        if (inputImage.Width > pageWidth) {
            scaleX = Convert.ToDouble(pageWidth) / Convert.ToDouble(inputImage.Width);
            scaleY = scaleX;
        }
        if (inputImage.Height * scaleY > pageHeight) {
            scaleY = scaleY * Convert.ToDouble(pageHeight) / Convert.ToDouble(inputImage.Height);
            scaleX = scaleY;
        }
        Bitmap outputImage = new Bitmap(Convert.ToInt16(inputImage.Width * scaleX), Convert.ToInt16(inputImage.Height * scaleY));
        using (Graphics g = Graphics.FromImage(outputImage))
            g.DrawImage(inputImage, 0, 0, outputImage.Width, outputImage.Height);
        return outputImage;
    }
