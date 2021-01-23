    Bitmap clonedImage = originalImage.Clone(rect, originalImage.PixelFormat);
    float gamma = 1.0f; // no change in gamma
    
    float adjustedBrightness = brightness - 1.0f;
    // create matrix that will brighten and contrast the image
    float[][] ptsArray ={
            new float[] {contrast, 0, 0, 0, 0}, // scale red
            new float[] {0, contrast, 0, 0, 0}, // scale green
            new float[] {0, 0, contrast, 0, 0}, // scale blue
            new float[] {0, 0, 0, alpha, 0},
            new float[] {adjustedBrightness, adjustedBrightness, adjustedBrightness, 0, 1}};
    
    var imageAttributes = new ImageAttributes();
    imageAttributes.ClearColorMatrix();
    imageAttributes.SetColorMatrix(new ColorMatrix(ptsArray), ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    imageAttributes.SetGamma(gamma, ColorAdjustType.Bitmap);
    
    // Copy back to the original image from the cloned image
    Graphics g = Graphics.FromImage(originalImage);
    g.DrawImage(clonedImage, new Rectangle(0, 0, clonedImage.Width, clonedImage.Height)
    	, rect.left, rect.top, rect.Width, rect.Height,
    	GraphicsUnit.Pixel, imageAttributes);
    g.Flush();
