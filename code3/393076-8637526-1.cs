    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            int initialX = 0, initialY = 0; // for example.
            Rectangle.X = (e.X - FirstPoint.X) + initialX; 
            Rectangle.Y = (e.Y - FirstPoint.Y) + initialY;
            Image.Invalidate();
        }
    }
