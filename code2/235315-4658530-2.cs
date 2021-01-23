    // Save images to disk.
    using (System.Drawing.Image image = System.Drawing.Image.FromStream(file.InputStream))
    using (System.Drawing.Image thumbnailImage = image.GetThumbnailImage(140, Convert.ToInt32((image.Height / (image.Width / 140))), null, IntPtr.Zero))
    {
        if (image != null)
        {
            image.Save(imageFilePath);
            thumbnailImage.Save(thumbnailImagePath); 
        }
        else
            throw new ArgumentNullException("Image stream is null");
    }
