    var points = new Point[arrayX.Length];
    for(int x = 0; x<points.Length; x++){
      points[x] = new Point(arrayX[x], arrayY[x]);
    }
    foreach(Point r in points.OrderBy(p=>p.X)){
      Rectangle rect = new Rectangle(r.X /* blobid[i].name.Length * 6)*/, imageBoxMain.Image.Height - r.Y - 6, 100, 20);
      g.DrawString(Convert.ToString(i + 1), annotationFont, annotationPen.Brush, new System.Drawing.Point(rect.X, rect.Y));
    }
