    System.Drawing.Image primaryImage = Image.FromFile(@"Your file path");//or resource..
    using (Graphics graphics = Graphics.FromImage(primaryImage))//get the underlying graphics object from the image.
    {
        using (Bitmap overlayImage = new Bitmap(primaryImage.Width, primaryImage.Hieght,
             System.Drawing.Imaging.PixelFormat.Format32bppArgb)//or your overlay image from file or resource...
        {
            graphics.DrawImage(overlayImage, new Point(0, 0));//this will draw the overlay image over the base image at (0, 0) coordination.
        }
    }
    Control.Image = primaryImage;
