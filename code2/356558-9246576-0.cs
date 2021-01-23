        /// <summary>
        /// Resizes image with high quality
        /// </summary>
        /// <param name="imgToResize">image to be resized</param>
        /// <param name="size">new size</param>
        /// <returns>new resized image</returns>
        public Image GetResizedImage(Image imgToResize, Size size) 
        {
          try
          {
           if (imgToResize != null && size != null)
           {
             if (imgToResize.Height == size.Height && imgToResize.Width == size.Width)
             {
                Image newImage = (Image)imgToResize.Clone();
                imgToResize.Dispose();
                return newImage;
             }
             else
             {
                Image newImage = (Image)imgToResize.Clone();
                imgToResize.Dispose();
                Bitmap b = new Bitmap(size.Width, size.Height);
                Graphics g = Graphics.FromImage((Image)b);
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.DrawImage(newImage, 0, 0, size.Width, size.Height);
                g.Dispose();
                return (Image)b;
            }
          }
           return null;
         }
         catch (Exception e)
         {
           log.Error("Exception in Resizing an image ", e);
           return null;
         }
        }
 
