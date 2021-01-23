    using System.Drawing;
    using System.Drawing.Drawing2D;
    private static byte[] PrepImageForUpload(HttpPostedFileBase FileData)
    {
        using (Bitmap origImage = new Bitmap(FileData.InputStream))
        {
            int maxWidth = 165;
            
            int newWidth = origImage.Width;
            int newHeight = origImage.Height;          
            if (origImage.Width < newWidth) //Force to max width
            {
                newWidth = maxWidth;
                newHeight = origImage.Height * maxWidth / origImage.Width;   
            }
            
            using (Bitmap newImage = new Bitmap(newWidth, newHeight))
            {
                using (Graphics gr = Graphics.FromImage(newImage))
                {
                    gr.SmoothingMode = SmoothingMode.AntiAlias;
                    gr.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    gr.PixelOffsetMode = PixelOffsetMode.HighQuality;
                    gr.DrawImage(origImage, new Rectangle(0, 0, newWidth, newHeight));
                    MemoryStream ms = new MemoryStream();
                    newImage.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                    return ms.ToArray();
                }
            }
        }
    }
