    class Rectitive{
      private Rectangle r;
      public Rectangle R { get{return r}; private set; }
      public int Width { get { return r.Width } set { r.Width = math.Abs(value); } }
      public Rectitive(int x, int y, int w, int h){
        r = new Rectangle(Math.Abs(x) ...);
      }
    }
    e.Graphics.DrawRectangle(myRectitive.R);
