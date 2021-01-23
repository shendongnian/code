    using (var sourceBmp = new Bitmap(sourcePath))
    {
      decimal aspect = (decimal)sourceBmp.Width / (decimal)sourceBmp.Height;
      int newHeight = (int)(newWidth / aspect);
        
       using (var destinationBmp = new Bitmap(newWidth, newHeight))
       {
         using (var destinationGfx = Graphics.FromImage(destinationBmp))
         {
           destinationGfx.InterpolationMode = InterpolationMode.HighQualityBicubic;
           destinationGfx.DrawImage(sourceBmp, new Rectangle(0, 0, destinationBmp.Width, destinationBmp.Height));
           destinationBmp.Save(destinationPath, ImageFormat.Jpeg);
          }
        }
    }
