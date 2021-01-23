    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            // Increment rectangle-location by mouse-location delta.
            Rectangle.X += e.X - FirstPoint.X; 
            Rectangle.Y += e.Y - FirstPoint.Y; 
    
            // Re-calibrate on each move operation.
            FirstPoint = new MovePoint { X = e.X, Y = e.Y };
            Image.Invalidate();
        }
    }
