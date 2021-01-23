    // update video feeds
    void nui_VideoFrameReady(object sender, ImageFrameReadyEventArgs e)
    {
        PlanarImage image = e.ImageFrame.Image;
        // Large video feed
        video.Source = BitmapSource.Create(image.Width, image.Height, 96, 96, PixelFormats.Bgr32, null, image.Bits, image.Width * image.BytesPerPixel);
        // X and Y coordinates of the smaller image, and the width and height of smaller image
        int xCoord = 100, yCoord = 150, width = 60, height = 60;
        // Create an array to copy data into
        byte[] bytes = new byte[width * height * image.BytesPerPixel];
        // Copy over the relevant bytes
        for (int i = 0; i < height; i++) 
        {
            for (int j = 0; j < width * image.BytesPerPixel; j++)
            {
                bytes[i * (width * image.BytesPerPixel) + j] = image.Bits[(i + yCoord) * (image.Width * image.BytesPerPixel) + (j + xCoord * image.BytesPerPixel)];
            }
        }
        // Create the smaller image
        smallVideo.Source = BitmapSource.Create(width, height, 96, 96, PixelFormats.Bgr32, null, bytes, width * image.BytesPerPixel);
    }
