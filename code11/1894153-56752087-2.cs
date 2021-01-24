    try
    {
        Image rectCroppedImage = originalImage.Clone(CropRect, originalImage.PixelFormat);
        double r = rectCroppedImage.Height; // because you are centered on your circle
        Bitmap img = new Bitmap(rectCroppedImage);
        for (int x = 0; x < img.Width; x++)
        {
            for (int y = 0; y < img.Height; y++)
            {
                // offset to center
                int virtX = x - img.Width / 2;
                int virtY = y - img.Height / 2;
                if (Math.Sqrt(virtX * virtX + virtY * virtY) > r)
                {
                    img.SetPixel(x, y, Color.Transparent);
                }
            }
        }
        return img; // your circle cropped image
    }
    catch (Exception ex)
    {
    }
