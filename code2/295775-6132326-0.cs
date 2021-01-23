    using (var medBitmap = new Bitmap(fullSizeImage, newImageW, newImageH))
    {
      using (var g = Graphics.FromImage(medBitmap))
      {
        g.InterpolationMode = InterpolationMode.HighQualityBicubic;
        g.DrawImage(medBitmap, 0, 0);
      }
      medBitmap.Save(HttpContext.Current.Server.MapPath("~/Media/Items/Images/" + itemId + ".jpg"), ImageFormat.Jpeg);
    }
