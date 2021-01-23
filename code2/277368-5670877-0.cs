    using (var b = new Bitmap(OtherWidth, OtherHeight))
    using (var g = Graphics.FromImage(b))
    {
         using (var brush = new SolidBrush(Color.Red))
         {
             g.FillRectangle(brush, 0, 0, b.Width, b.Height);
         }
         using (var pic = new Bitmap(ruta2))
         {
             g.DrawImage(pic, 0, 0, pic.Height, pic.Width);
         }
         b.Save(ruta2, ImageFormat.Jpeg);
     }
