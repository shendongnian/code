    private void MouseMoveHandler(object sender, MouseEventArgs e)
     {
         /// Get the x and y coordinates of the mouse pointer.
         System.Windows.Point position = e.GetPosition(this);
         double pX = position.X;
         double pY = position.Y;
         /// Sets eclipse to the mouse coordinates.
         Canvas.SetLeft(ellipse, pX);
         Canvas.SetTop(ellipse, pY);
         Canvas.SetRight(ellipse, pX);
      }
