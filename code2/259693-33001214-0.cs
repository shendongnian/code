        private static Image Resize(Image img, int width, int height)
        {
            Bitmap b = new Bitmap(width, height);
            using (Graphics g = Graphics.FromImage((Image)b))
            {
                g.DrawImage(img, 0, 0, width, height);
            }
            return (Image)b;
        }
        public static Image Crop(Image image, int width, int height)
        {
            int cropx = image.Width > width ? image.Width / 2 - width / 2 : 0;
            int cropy = image.Height > height ? image.Height / 2 - height / 2 : 0;
            width = image.Width > width ? width : image.Width;
            height = image.Height > height ? height : image.Height;
            Rectangle cropRect = new Rectangle(cropx, cropy, width, height);
            var target = new Bitmap(cropRect.Width, cropRect.Height);
            using (Graphics g = Graphics.FromImage(target))
            {
                g.DrawImage(image, new Rectangle(0, 0, target.Width, target.Height), cropRect, GraphicsUnit.Pixel);
            }
            return target;
        }
        public static Image FitToSize(Image image, int width, int height)
        {
            var wratio = 1.0 * image.Width / width;
            var hratio = 1.0 * image.Height / height;
            int wresize;
            int hresize;
            if (wratio >= hratio && wratio > 1)
            {
                wresize = (int)Math.Round((double)image.Width / hratio);
                hresize = height;
                image = Resize(image, wresize, hresize);
                image = Crop(image, width, height);  
            }
            else if (hratio >= wratio && hratio > 1)
            {
                hresize = (int)Math.Round((double)image.Height / wratio);
                wresize = width;
                image = Resize(image, wresize, hresize);
                image = Crop(image, width, height);
            }
            return image;
        }
