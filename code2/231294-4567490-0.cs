    byte[] IImageResizer.CreateThumbnailBytes(byte[] originalImage)
        {
            Image thumbnail = null;
            Image tempImage = Image.FromStream(new MemoryStream(originalImage));
            int desiredWidth = 160;
            int newPixelWidth = tempImage.Width;
            int newPixelHeight = tempImage.Height;
            if (newPixelWidth > desiredWidth)
            {
                float resizePercent = ((float)desiredWidth / (float)tempImage.Width);
                newPixelWidth = (int)(tempImage.Width * resizePercent) + 1;
                newPixelHeight = (int)(tempImage.Height * resizePercent) + 1;
            }
            Bitmap bitmap = new Bitmap(newPixelWidth, newPixelHeight);
            using (Graphics graphics = Graphics.FromImage((Image)bitmap))
            {
                graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                graphics.DrawImage(tempImage, 0, 0, newPixelWidth, newPixelHeight);
            }
            thumbnail = (Image)bitmap;
            MemoryStream ms = new MemoryStream();
            thumbnail.Save(ms, ImageFormat.Jpeg);
            return ms.ToArray();
        }
