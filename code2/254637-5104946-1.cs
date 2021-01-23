    private void AddBorderForFrameworkElement(FrameworkElement element)
    {
        Rect bounds = element.TransformToVisual(canvas).TransformBounds(new Rect(element.RenderSize));
        Border boundingBox = new Border { BorderBrush = Brushes.Red, BorderThickness = new Thickness(1) };
        Canvas.SetLeft(boundingBox, bounds.Left);
        Canvas.SetTop(boundingBox, bounds.Top);
        boundingBox.Width = bounds.Width;
        boundingBox.Height = bounds.Height;
        canvas.Children.Add(boundingBox);            
    }
