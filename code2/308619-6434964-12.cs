    static Brush CreateGridBrush(Rect bounds, Size tileSize)
    {
        var gridColor = Brushes.Black;
        var gridThickness = 1.0;
        var tileRect = new Rect(tileSize);
        var gridTile = new DrawingBrush
        {
            Stretch = Stretch.None,
            TileMode = TileMode.Tile,
            Viewport = tileRect,
            ViewportUnits = BrushMappingMode.Absolute,
            Drawing = new GeometryDrawing
            {
                Pen = new Pen(gridColor, gridThickness),
                Geometry = new GeometryGroup
                {
                    Children = new GeometryCollection
                    {
                        new LineGeometry(tileRect.TopLeft, tileRect.BottomRight),
                        new LineGeometry(tileRect.BottomLeft, tileRect.TopRight)
                    }
                }
            }
        };
        var offsetGrid = new DrawingBrush
        {
            Stretch = Stretch.None,
            AlignmentX = AlignmentX.Left,
            AlignmentY = AlignmentY.Top,
            Transform = new TranslateTransform(bounds.Left, bounds.Top),
            Drawing = new GeometryDrawing
            {
                Geometry = new RectangleGeometry(new Rect(bounds.Size)),
                Brush = gridTile
            }
        };
        return offsetGrid;
    }
