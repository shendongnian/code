    private Point currentMousePos;
    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        // Save the current position of the mouse
        currentMousePos = e.Location;
        // Force the picture box to be repainted
        pictureBox1.Invalidate();
    }
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        // Create a pen object that we'll use to draw
        // (change these parameters to make it any color and size you want)
        using (Pen p = new Pen(Color.Blue, 3.0F))
        {
            // Create a rectangle with the initial cursor location as the upper-left
            // point, and the current cursor location as the bottom-right point
            Rectangle currentRect = Rectangle.FromLTRB(
                                                       this.initialMousePos.X,
                                                       this.initialMousePos.Y,
                                                       currentMousePos.X,
                                                       currentMousePos.Y);
            // Draw the rectangle
            e.Graphics.DrawRectangle(p, currentRect);
        }
    }
