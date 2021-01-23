    interface IDrawing
    {
       void Scale(float sx, float sy);
       void Translate(float dx, float dy);
       void SetPen(Color col, float thickness);
       void DrawLine(Point from, Point to);
       // ... more methods
    }
    class GdiPlusDrawing : IDrawing
    {
       private float scale;
       private Graphics graphics;
       private Pen pen;
       public GdiPlusDrawing(Graphics g)
       {
          float scale = 1.0f;
       }
       
       public void Scale(float s)
       {
           scale *= s;
           graphics.ScaleTransform(s,s);
       }
       
       public void SetPen(Color color, float thickness)
       {
           // Use scale to compensate pen thickness.
           float penThickness = thickness/scale;
           pen = new Pen(color, penThickness);   // Note, need to dispose.
       }
       // Implement rest of IDrawing
    }
