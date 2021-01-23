    public void CreateAPath()
    
    {
    
        // Create a blue and a black Brush
    
        SolidColorBrush blueBrush = new SolidColorBrush();
    
        blueBrush.Color = Colors.Blue;
    
        SolidColorBrush blackBrush = new SolidColorBrush();
    
        blackBrush.Color = Colors.Black;
    
     
    
        // Create a Path with black brush and blue fill
    
        Path bluePath = new Path();
    
        bluePath.Stroke = blackBrush;
    
        bluePath.StrokeThickness = 3;
    
        bluePath.Fill = blueBrush;
    
     
    
        // Create a line geometry
    
        LineGeometry blackLineGeometry = new LineGeometry();
    
        blackLineGeometry.StartPoint = new Point(20, 200);
    
        blackLineGeometry.EndPoint = new Point(300, 200);
    
     
    
        // Create an ellipse geometry
    
        EllipseGeometry blackEllipseGeometry = new EllipseGeometry();
    
        blackEllipseGeometry.Center = new Point(80, 150);
    
        blackEllipseGeometry.RadiusX = 50;
    
        blackEllipseGeometry.RadiusY = 50;
    
     
    
        // Create a rectangle geometry
    
        RectangleGeometry blackRectGeometry = new RectangleGeometry();
    
        Rect rct = new Rect();
    
        rct.X = 80;
    
        rct.Y = 167;
    
        rct.Width = 150;
    
        rct.Height = 30;
    
        blackRectGeometry.Rect = rct;
    
     
    
        // Add all the geometries to a GeometryGroup.
    
        GeometryGroup blueGeometryGroup = new GeometryGroup();
    
        blueGeometryGroup.Children.Add(blackLineGeometry);
    
        blueGeometryGroup.Children.Add(blackEllipseGeometry);
    
        blueGeometryGroup.Children.Add(blackRectGeometry);
    
     
    
        // Set Path.Data
    
        bluePath.Data = blueGeometryGroup;
    
     
    
        LayoutRoot.Children.Add(bluePath);
    
    }
