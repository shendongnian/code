    private static ColorMatrix GrayscaleMatrix = new ColorMatrix(
        new float[][]
        {
            new float[] {0.30f, 0.30f, 0.30f, 0, 0},
            new float[] {0.59f, 0.59f, 0.59f, 0, 0},
            new float[] {0.11f, 0.11f, 0.11f, 0, 0},
            new float[] {0, 0, 0, 1, 0},
            new float[] {0, 0, 0, 0, 1}
        }
    );
    public static void ApplyGrayscaleTransformation(string inputPath, string outputPath)
    {
        using (var image = Bitmap.FromFile(inputPath))
        {
            using (var graphics = Graphics.FromImage(image))
            {
                using (var attributes = new ImageAttributes())
                {
                    attributes.SetColorMatrix(GrayscaleMatrix);
                    graphics.DrawImage(image, 
                        new Rectangle(0,0,image.Width, image.Height), 
                        0, 0, image.Width, image.Height, GraphicsUnit.Pixel, 
                        attributes);
                }
            }
            image.Save(outputPath);
        }
    }
