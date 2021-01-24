    using (Image image = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\Desert.jpg"))
        using (Image watermarkImage = Image.FromFile(@"C:\Users\Public\Pictures\Sample Pictures\watermark.png"))
        using (Graphics imageGraphics = Graphics.FromImage(image))
        using (TextureBrush watermarkBrush = new TextureBrush(watermarkImage))
        {
            int x = (image.Width / 2 - watermarkImage.Width / 2);
            int y = (image.Height / 2 - watermarkImage.Height / 2);
            watermarkBrush.TranslateTransform(x, y);
            imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width+1, watermarkImage.Height)));
            image.Save(@"C:\Users\Public\Pictures\Sample Pictures\Desert_watermark.jpg");
        }
