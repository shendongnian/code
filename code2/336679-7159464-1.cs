    public static void SaveBitmapPart(System.Drawing.Image image, System.Drawing.RectangleF sourceRect, string pathToSave )
    {
        using (var bmp = new System.Drawing.Bitmap((int)sourceRect.Width, (int)sourceRect.Height))
        {
            using (var graphics = System.Drawing.Graphics.FromImage(bmp))
            {
                graphics.DrawImage(image, 0.0f, 0.0f, sourceRect, System.Drawing.GraphicsUnit.Pixel);
            }
            bmp.Save(pathToSave);
        }
    }
