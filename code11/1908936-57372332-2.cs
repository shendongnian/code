    private void MovShp_MouseDown(object sender, MouseButtonEventArgs e)
    {
        drag = true;
        Cursor = Cursors.Hand;
        startPt = e.GetPosition(CanvasImplant);
        Mouse.Capture(CanvasImplant);
    }
    
    private void MovShp_MouseUp(object sender, MouseButtonEventArgs e)
    {
        drag = false;
        Cursor = Cursors.Arrow;
        Mouse.Capture(null);
    }
    
    private void MovShp_MouseMove(object sender, MouseEventArgs e)
    {
        if (drag)
        {
            double deltaX = e.GetPosition(CanvasImplant).X - startPt.X;
            double deltaY = e.GetPosition(CanvasImplant).Y - startPt.Y;
    
            var newX = deltaX + MovableShape.GetLeft();
            var newY = deltaY + MovableShape.GetTop();
    
            if (newX < 0)
                newX = 0;
            else if (newX + MovableShape.ActualWidth > CanvasImplant.ActualWidth)
                newX = CanvasImplant.ActualWidth - MovableShape.ActualWidth;
    
            if (newY < 0)
                newY = 0;
            else if (newY + MovableShape.ActualHeight > CanvasImplant.ActualHeight)
                newY = CanvasImplant.ActualHeight - MovableShape.ActualHeight;
    
            MovableShape.SetLeft( newX);
            MovableShape.SetTop( newY);
    
            startPt = new Point(newX, newY);
        }
    
    }
