    protected void DrawIBeam(Graphics g, Point fromPoint, Point toPoint)
    {
      using (GraphicsPath hPath = new GraphicsPath())
      {
        hPath.AddLine(new Point(-5, 0), new Point(5, 0));
        CustomLineCap myCap = new CustomLineCap(null, hPath);
        myCap.SetStrokeCaps(LineCap.Round, LineCap.Round);
        using (Pen myPen = new Pen(Color.Black, 2))
        {
          myPen.CustomStartCap = myCap;
          myPen.CustomEndCap = myCap;
          g.DrawLine(myPen, fromPoint, toPoint);
        }
      }
    }
