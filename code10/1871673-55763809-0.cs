    private void PathPolyline_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
	{
	  Brush brush = Brushes.Black;
	  Pen pen = new Pen(brush, 10.0);
	  pen.EndLineCap = PenLineCap.Square;
	  //
	  Path path = sender as Path;
	  GeometryGroup gg = path.Data as GeometryGroup;
	  PathGeometry pg = path.Data as PathGeometry;
	  PathGeometry pg2 = pg.GetWidenedPathGeometry(pen);
	  //
	  Transform tr = Transform.Identity;
	  PathGeometry pg324 = Geometry.Combine(pg, pg2, GeometryCombineMode.Intersect, tr);
	  pg.AddGeometry(pg324);
	}
