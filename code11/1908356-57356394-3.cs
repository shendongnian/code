    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        Size sz = pictureBox1.ClientSize;
        Point pt = pictureBox1.PointToClient(Control.MousePosition);
        e.Graphics.DrawLine(Pens.OrangeRed, pt.X, 0, pt.X, sz.Height);
        e.Graphics.DrawLine(Pens.OrangeRed, 0, pt.Y, sz.Width, pt.Y);
    }
