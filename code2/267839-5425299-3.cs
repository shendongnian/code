    using (System.Drawing.Image fullsizeImage =
             System.Drawing.Image.FromFile(originalFilePath))
    {
           // these calls to RotateFlip aren't essential, but they prevent the image 
           // from using its built-in thumbnail, which is invariably poor quality.
           // I like to think of it as shaking the thumbnail out ;)
           fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
           fullsizeImage.RotateFlip(System.Drawing.RotateFlipType.Rotate180FlipNone);
           using (System.Drawing.Image thumbnailImage = 
             fullsizeImage.GetThumbnailImage(newWidth, newHeight, null, IntPtr.Zero))
           {
                thumbnailImage.Save(newFilePath);
           }
    }
