    private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
    {
        pictureBox1.Invalidate();
        float f = 1f * pictureBox2.ClientSize.Width / pictureBox1.ClientSize.Width;
        Size s2 = pictureBox2.Parent.ClientSize;
        Point p2 = Point.Round(new PointF(s2.Width/2 - e.X * f , s2.Height/2 - e.Y * f ));
        pictureBox2.Location = p2;
    }
