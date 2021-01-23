    public Bitmap RenderText(string text, double x, double y)
    {
       Bitmap bitmap = new Bitmap(400, 400);
       using (Graphics g = new Graphics(bitmap))
       {
          using (Font font = SystemFonts....)
          {
             using (Brush brush = new SolidColorBrush(...))
             {
                g.DrawString(text, font, brush, new Point(x, y));
             }
          }
       }
       return bitmap;
   }
