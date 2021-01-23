    private void Border_SizeChanged(object sender, SizeChangedEventArgs e)
    {
        double cutOff = 20;
        var line = BorderClipFigure.Segments[0] as LineSegment;
        line.Point = new Point(e.NewSize.Width, 0);
        line = BorderClipFigure.Segments[1] as LineSegment;
        line.Point = new Point(e.NewSize.Width, e.NewSize.Height - cutOff);
        line = BorderClipFigure.Segments[2] as LineSegment;
        line.Point = new Point(e.NewSize.Width - cutOff, e.NewSize.Height);
        line = BorderClipFigure.Segments[3] as LineSegment;
        line.Point = new Point(0, e.NewSize.Height);
    }
            
