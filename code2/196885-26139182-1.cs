    void panel1_MouseMove(object sender, MouseEventArgs e)
    {
        Rectangle r = new Rectangle(e.X, e.Y, 10, 10);
        using (Graphics g = Graphics.FromImage(m_image))
        {
            g.FillEllipse(Brushes.Black, r);
        }
        panel1.Invalidate(r);
    }
