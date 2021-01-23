     Rectangle r = new Rectangle(new Point(50, 100), new Size(500, 100));
     bool b;
     // say Point p is set.
     // say Pen pen is set.
     using (var gp = new GraphicsPath())
     using (var pen = new Pen(Color.Black, 44)) {
        gp.AddRectangle(r);
        bool b = gp.IsVisible(point) || gp.IsOutlineVisible(point, pen);              
      }
