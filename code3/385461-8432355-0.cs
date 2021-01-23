        if (bitmap.Width < cropWidth && bitmap.Height < cropHeight)
        {
            Bitmap newImage = new Bitmap(cropWidth, cropHeight, bitmap.PixelFormat);
            using (Graphics g = Graphics.FromImage(newImage))
            {
                // fill target image with white color
                g.FillRectangle(Brushes.White, 0, 0, cropWidth, cropHeight);
                // place source image inside the target image
                var dstX = cropWidth - bitmap.Width;
                var dstY = cropHeight - bitmap.Height;
                g.DrawImage(bitmap, dstX, dstY);
            }
            return newImage;
        }
