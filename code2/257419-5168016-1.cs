    private Image Crop()
    {
        Bitmap croppedImage = new Bitmap(_cropRectangle.Width, _cropRectangle.Height);
        using (Graphics g = Graphics.FromImage(croppedImage))
        {
            g.DrawImage(pBox.Image, 0, 0, _cropRectangle, GraphicsUnit.Pixel);
        }
        return croppedImage;
    }
