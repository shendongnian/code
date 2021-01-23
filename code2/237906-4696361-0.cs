    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
        using (Pen p = new Pen(Color.Black, 2))
        {
            e.Graphics.DrawLine(p, new Point(pictureBox1.Width / 2, 0), new Point(pictureBox1.Width / 2, pictureBox1.Height));
        }
    }
