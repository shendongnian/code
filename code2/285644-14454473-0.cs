    Bitmap original = new Bitmap( 200, 200 );     
    Bitmap copy = new Bitmap(original.Width, original.Height);
    using (Graphics graphics = Graphics.FromImage(copy))
    {
      Rectangle imageRectangle = new Rectangle(0, 0, copy.Width, copy.Height);
      graphics.DrawImage( original, imageRectangle, imageRectangle, GraphicsUnit.Pixel);
    }
