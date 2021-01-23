        public static Image ScaleImage(string fileName, int maxWidth, int maxHeight)
        {
            var image = Image.FromFile(fileName);
            var ratioX = (double)maxWidth / image.Width;
            var ratioY = (double)maxHeight / image.Height;
            var ratio = Math.Min(ratioX, ratioY);
            var newWidth = (int)(image.Width * ratio);
            var newHeight = (int)(image.Height * ratio);
            var newImage = new Bitmap(newWidth, newHeight);
            var g = Graphics.FromImage(newImage);
            g.Clear(Color.White); // matters for transparent images
            g.DrawImage(image, 0, 0, newWidth, newHeight);
            return newImage;
        }
