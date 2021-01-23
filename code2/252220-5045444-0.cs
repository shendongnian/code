    /// getNewDimensions
    static private void getNewDimensions(int ImageWidth, int ImageHeight, Orientation orientation, out int NewWidth, out int NewHeight) {
        double scaleX = 1;
        double scaleY = 1;
        int pageWidth = orientation == Orientation.Portrait ? (int)PageDimensions.Width : (int)PageDimensions.Height;
        int pageHeight = orientation == Orientation.Portrait ? (int)PageDimensions.Height : (int)PageDimensions.Width;
        if (ImageWidth > pageWidth) {
            scaleX = Convert.ToDouble(pageWidth) / Convert.ToDouble(ImageWidth);
            scaleY = scaleX;
        }
        if (ImageHeight * scaleY > pageHeight) {
            scaleY = scaleY * Convert.ToDouble(pageHeight) / Convert.ToDouble(ImageHeight);
            scaleX = scaleY;
        }
        NewWidth = ImageWidth * scaleX;
        NewHeight = ImageHeight * scaleY;
    }
    /// resizeBitmap
    static private Bitmap resizeBitmap(Bitmap inputBitmap, Orientation orientation) {
        int NewWidth = 0;
        int NewHeight = 0;
        getNewDimensions(inputBitmap.Width, inputBitmap.Width, orientation, NewWidth, NewHeight);
        Bitmap outputImage = new Bitmap(Convert.ToInt16(newWidth), Convert.ToInt16(newHeight));
        using (Graphics g = Graphics.FromImage(outputImage)) 
            g.DrawImage(inputBitmap, 0, 0, outputImage.Width, outputImage.Height);
        return outputImage;
    }
    /// resizeImage (I'll leave as an exercise to the reader)
