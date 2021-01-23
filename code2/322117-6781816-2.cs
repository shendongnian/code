    foreach (FrameworkElement nextElement in myCanvas.Children)
    {
        double left = Canvas.GetLeft(nextElement);
        double top = Canvas.GetTop(nextElement);
        double right = Canvas.GetRight(nextElement);
        double bottom = Canvas.GetBottom(nextElement);
        if (double.IsNaN(left))
        {
            if (double.IsNaN(right) == false)
                left = right - nextElement.ActualWidth;
            else
                continue;
        }
        if (double.IsNaN(top))
        {
            if (double.IsNaN(bottom) == false)
                top = bottom - nextElement.ActualHeight;
            else
                continue;
        }
        Rect eleRect = new Rect(left, top, nextElement.ActualWidth, nextElement.ActualHeight);
        if (myXY.X >= eleRect.X && myXY.Y >= eleRect.Y && myXY.X <= eleRect.Right && myXY.Y <= eleRect.Bottom)
        {
            // Add to intersects list
        }
    }
        
