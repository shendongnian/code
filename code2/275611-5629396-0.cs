    using (Bitmap image = new Bitmap(context.Server.MapPath("images/stars_5.png")))
    {
       using(MemoryStream ms = new MemoryStream())
       {
          image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
          ms.WriteTo(context.Response.OutputStream);
       }
    }
