       Bitmap bitmap = ...
       Bitmap thumbBitmap = new System.Drawing.Bitmap(thumbWidth, thumbHeight);
       using (Graphics g = Graphics.FromImage(thumbBitmap))
       {
          g.InterpolationMode = InterpolationMode.HighQualityBicubic;
          g.DrawImage(bitmap, 0, 0, thumbWidth, thumbHeight);
       }
