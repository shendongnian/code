    public byte[] ResizeImageToBytes(string path, int size, string name)
    {
        using (var newImage = Image.FromFile(path))
        {
            int newWidth; int newHeight;
            if (size == 470)
            {
                if (newImage.Height != 250)
                {
                    newWidth = (int)Math.Round(newImage.Width * (100 / (newImage.Height / 250)) * 0.01);
                    newHeight = 250;
                }
                else
                {
                    newWidth = newImage.Width;
                    newHeight = newImage.Height;
                }
            }
            else
            {
                if (newImage.Width > newImage.Height)
                {
                    newWidth = size;
                    newHeight = newImage.Height * size / newImage.Width;
                }
                else
                {
                    newWidth = newImage.Width * size / newImage.Height;
                    newHeight = size;
                }
            }
            using (var thumb = new Bitmap(newWidth, newHeight))
            using (var gfx = Graphics.FromImage(thumb))
            {
                gfx.CompositingQuality = CompositingQuality.HighQuality;
                gfx.SmoothingMode = SmoothingMode.HighQuality;
                gfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
                var rect = new Rectangle(0, 0, newWidth, newHeight);
                gfx.DrawImage(newImage, rect);
                using (var ms = new MemoryStream())
                {
                    thumb.Save(ms, newImage.RawFormat);
                    return ms.GetBuffer();
                }
            }
        }
    }
