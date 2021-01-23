    Image imageControl = new Image();
    imageControl.Source = originalImage;
    
    // Required because the Image control is not part of the visual tree (see doc)
    Size size = new Size(originalImage.PixelWidth, originalImage.PixelHeight);
    imageControl.Measure(size);
    Rect rect = new Rect(new Point(0, 0), size);
    imageControl.Arrange(ref rect);
    
    WriteableBitmap topHalf = new WriteableBitmap(originalImage.PixelWidth, originalImage.PixelHeight / 2);
    WriteableBitmap bottomHalf = new WriteableBitmap(originalImage.PixelWidth, originalImage.PixelHeight / 2);
    
    Transform transform = new TranslateTransform();
    topHalf.Render(originalImage, transform);
    transform.Y = originalImage.PixelHeight / 2;
    bottomHalf.Render(originalImage, transform);
