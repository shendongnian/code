    private Point _lastPosition;
    private void Window_MouseMove(object sender, MouseEventArgs e)
    {
      Point currentPosition = e.GetPosition(this);
      if (IsMovementBigEnough(_lastPosition, currentPosition))
      {
        // .. do stuff here 
      }
      _lastPosition = currentPosition;
    }
    public bool IsMovementBigEnough(Point previousMousePosition, Point currentPosition)
    {
      return (Math.Abs(currentPosition.X - previousMousePosition.X) >= SystemParameters.MinimumHorizontalDragDistance ||
           Math.Abs(currentPosition.Y - previousMousePosition.Y) >= SystemParameters.MinimumVerticalDragDistance);
    }
