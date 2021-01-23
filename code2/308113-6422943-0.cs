        public static Image RotateImage(Image image, Size size, float angle)
        {
            if (image == null)
            {
                throw new ArgumentNullException("image");
            }
    
            if (size.Width < 1 || size.Height < 1)
            {
                throw new ArgumentException("size must be larger than zero.");
            }
    
            Bitmap tempImage = new Bitmap(size.Width, size.Height);
    
            using (Graphics tempGraphics = Graphics.FromImage(tempImage))
            {
                PointF center = new PointF((float)size.Width / 2F, (float)size.Height / 2F);
    
                tempGraphics.TranslateTransform(center.X, center.Y, MatrixOrder.Prepend);
    
                tempGraphics.RotateTransform(angle != 180F ? angle : 182F/*at 180 exact angle the rotate make a small shift of image I don't know why!*/);
    
                tempGraphics.TranslateTransform(-center.X, -center.Y, MatrixOrder.Prepend);
    
                tempGraphics.DrawImage(image, new PointF());
            }
    
            return tempImage;
        }
