    System.Drawing.Bitmap bmpPostedImage = new System.Drawing.Bitmap(File1.PostedFile.InputStream);
         System.Drawing.Image objImage = ScaleImage(bmpPostedImage, 81);
         objImage.Save(SaveLocation,ImageFormat.Png);
         lblmsg.Text = "The file has been uploaded.";
----------
    public static System.Drawing.Image ScaleImage(System.Drawing.Image image, int maxHeight)
            {
                var ratio = (double)maxHeight / image.Height;
        
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);
        
                var newImage = new Bitmap(newWidth, newHeight);
                using (var g = Graphics.FromImage(newImage))
                {
                    g.DrawImage(image, 0, 0, newWidth, newHeight);
                }
                return newImage;
            }
