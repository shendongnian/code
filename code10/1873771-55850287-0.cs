    Bitmap Bolden(Bitmap bmp0)
    {
        float f = 2f;
        Bitmap bmp = new Bitmap(bmp0.Width, bmp0.Height);
        using (Bitmap bmp1 = new Bitmap(bmp0, new Size((int)( bmp0.Width * f),
                                                       (int)( bmp0.Height * f))))
        {
            float contrast = 1f;
            ColorMatrix colorMatrix = new ColorMatrix(new float[][]
                    {
                new float[] {contrast, 0, 0, 0, 0},
                new float[] {0,contrast, 0, 0, 0},
                new float[] {0, 0, contrast, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {0, 0, 0, 0, 1}
                    });
            ImageAttributes attributes = new ImageAttributes();
            attributes.SetColorMatrix(colorMatrix, ColorMatrixFlag.Default,
                                                    ColorAdjustType.Bitmap);
            attributes.SetGamma(7.5f, ColorAdjustType.Bitmap);
            Graphics g = Graphics.FromImage(bmp);
            g.DrawImage(bmp1, new Rectangle(0, 0, bmp.Width, bmp.Height),
                        0, 0, bmp1.Width, bmp1.Height, GraphicsUnit.Pixel, attributes);
        }
        return bmp;
    }
