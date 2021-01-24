    public class DrawLineItem
    {
      public Pen Pen { get; set; }
      public int StartX { get; set; }
      public int StartY { get; set; }
      public int EndX { get; set; }
      public int EndY { get; set; }
      public DrawLineItem(Pen pen, int startX, int startY, int endX, int endY)
      {
        Pen = pen;
        StartX = startX;
        StartY = startY;
        EndX = endX;
        EndY = endY;
      }
    }
