    private static void RenderMethod1(DrawingContext dc) {
        DrawingGroup drawingVisual = new DrawingGroup();
        using (DrawingContext context = drawingVisual.Open()) {
            Rect rect = new Rect(new System.Windows.Point(100, 100), new System.Windows.Size(320, 80));
            context.DrawRectangle(System.Windows.Media.Brushes.LightBlue, (System.Windows.Media.Pen)null, rect);
        }
        drawingVisual.Transform = new RotateTransform(30, 100, 100);
        dc.DrawDrawing(drawingVisual);
    }
