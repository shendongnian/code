    ColorMatrix matrix = new ColorMatrix();
    
    // This will change the image's opacity.
    matrix.Matrix33 = 0.5f;
    
    ImageAttributes imgAttrs = new ImageAttributes();
    imgAttrs.SetColorMatrix(matrix, ColorMatrixFlag.Default, ColorAdjustType.Bitmap);
    
    g.DrawImage(img, new Rectangle(0, 0, 50, 50), 0, 0, 50, 50, GraphicsUnit.Pixel, imgAttrs);
