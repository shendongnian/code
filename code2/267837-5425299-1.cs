    using (System.Drawing.Image fullsizeImage =
             System.Drawing.Image.FromFile(originalFilePath))
    {
           using (System.Drawing.Image thumbnailImage = 
             fullsizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero))
           {
                thumbnailImage.Save(newFilePath);
           }
    }
