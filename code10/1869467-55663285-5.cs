    public Bitmap AdjustBrightnessContrast(Image image, int contrastValue, int brightnessValue)
    {
        float brightness = -(brightnessValue / 100.0f);
        float contrast = contrastValue / 100.0f;
        using (Bitmap bitmap = new Bitmap(image.Width, image.Height, PixelFormat.Format32bppArgb))
        using (Graphics g = Graphics.FromImage(bitmap))
        using (ImageAttributes attributes = new ImageAttributes())
        {
            float[][] matrix = {
                new float[] { contrast, 0, 0, 0, 0},
                new float[] {0, contrast, 0, 0, 0},
                new float[] {0, 0, contrast, 0, 0},
                new float[] {0, 0, 0, 1, 0},
                new float[] {brightness, brightness, brightness, 1, 1}
            };
            Color color = Color.Orange;
            ColorMatrix colorMatrix = new ColorMatrix(matrix);
            attributes.SetColorMatrix(colorMatrix);
            g.DrawImage(image, new Rectangle(0, 0, bitmap.Width, bitmap.Height),
                0, 0, bitmap.Width, bitmap.Height, GraphicsUnit.Pixel, attributes);
            return (Bitmap)bitmap.Clone();
        }
    }
