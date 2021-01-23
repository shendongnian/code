    private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
    {
        // Save the final position of the mouse
        Point finalMousePos = e.Location;
        // Create the rectangle from the two points
        Rectangle drawnRect = Rectangle.FromLTRB(
                                                 this.initialMousePos.X,
                                                 this.initialMousePos.Y,
                                                 finalMousePos.X,
                                                 finalMousePos.Y);
        // Do whatever you want with the rectangle here
        // ...
    }
