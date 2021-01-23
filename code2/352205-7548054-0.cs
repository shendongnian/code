    public void Resize(Stream input, Stream output, int width, int height)
    {
        using (var image = Image.FromStream(input))
        using (var bmp = new Bitmap(width, height))
        using (var gr = Graphics.FromImage(bmp))
        {
            gr.CompositingQuality = CompositingQuality.HighSpeed;
            gr.SmoothingMode = SmoothingMode.HighSpeed;
            gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
            gr.DrawImage(image, new Rectangle(0, 0, width, height));
            bmp.Save(output, ImageFormat.Png);
        }
    }
