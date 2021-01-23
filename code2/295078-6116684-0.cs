    const double fingerMargin = 10.0;
    Point p = e.GetPosition(tree);
    Rect r = new Rect(p.X - fingerMargin, p.Y - fingerMargin, fingerMargin * 2, fingerMargin * 2); 
    var elements = VisualTreeHelper.FindElementsInHostCoordinates(r, ContentPanelCanvas);
    Line lineToRemove = elements.OfType<Line>().FirstOrDefault();
    if (lineToRemove != null)
    {
        ContentPanelCanvas.Children.Remove(lineToRemove);
    }
