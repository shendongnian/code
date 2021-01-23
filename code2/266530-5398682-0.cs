    public class(path,wid,height,boolean)
    { 
    System.Drawing.Image myThumbnail150;
                System.Drawing.Image.GetThumbnailImageAbort myCallback = new System.Drawing.Image.GetThumbnailImageAbort(ThumbnailCallback);
                System.Drawing.Image imagesize = System.Drawing.Image.FromFile(pic.FilePath);
                using (Bitmap bitmapNew = new Bitmap(imagesize))
                {
               
                double maxWidth = Convert.ToDouble(ConfigurationSettings.AppSettings["ImageWidth"]);
                double maxHeight = Convert.ToDouble(ConfigurationSettings.AppSettings["ImageHeight"]);
                int w = imagesize.Width;
                int h = imagesize.Height;
                // Longest and shortest dimension 
                int longestDimension = (w > h) ? w : h;
                int shortestDimension = (w < h) ? w : h;
                // propotionality  
                float factor = ((float)longestDimension) / shortestDimension;
                // default width is greater than height    
                double newWidth = maxWidth;
                double newHeight = maxWidth / factor;
                // if height greater than width recalculate  
                if (w < h)
                {
                    newWidth = maxHeight / factor;
                    newHeight = maxHeight;
                }
                myThumbnail150 = bitmapNew.GetThumbnailImage((int)newWidth, (int)newHeight, myCallback, IntPtr.Zero);
                string name = pic.Name.Replace(Path.GetExtension(pic.Name), ".Bmp");
                //Create a new directory name ThumbnailImage
                //Save image in TumbnailImage folder
                myThumbnail150.Save(yourpath+ name, System.Drawing.Imaging.ImageFormat.Bmp);
                bitmapNew.Dispose();
    }
