    var brickBrush = new DrawingBrush
	{
		Viewport = new Rect(0, 0, 60, 80),
		ViewportUnits = BrushMappingMode.Absolute,
		Viewbox = new Rect(0, 0, 60, 80),
		ViewboxUnits = BrushMappingMode.Absolute,
		TileMode = TileMode.Tile,
		Drawing = new GeometryDrawing
		{
			Brush = new SolidColorBrush(Color.FromRgb(0xB1, 0x78, 0x33)),
			Geometry = new GeometryGroup
			{
				Children = new GeometryCollection(new Geometry[] {
					new RectangleGeometry(new Rect( 0,   0, 60, 40)),
					new RectangleGeometry(new Rect( 30, 40, 60, 40)),
					new RectangleGeometry(new Rect(-30, 40, 60, 40))
				}),						
			},
			Pen = new Pen(new SolidColorBrush(Color.FromRgb(0xE1, 0xD7, 0xBD)), 5)
		}
	};
	theRectangle.Fill = brickBrush;
