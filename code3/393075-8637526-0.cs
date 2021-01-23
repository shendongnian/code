    private void Image_MouseMove(object sender, MouseEventArgs e)
    {
        if (e.Button == MouseButtons.Left)
        {
            Rectangle.X = e.X - FirstPoint.X; // possibly add an initial, constant X
            Rectangle.Y = e.Y - FirstPoint.Y; // possibly add an initial, constant Y
            pictureBox1.Invalidate();
        }
    }
