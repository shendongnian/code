    private void button1_Click(object sender, EventArgs e)
    {
        var s = 300;
        var c = new FrameControl();
        c.Size = new Size(s, s);
        c.Location = new Point((pictureBox1.Width - s) / 2, (pictureBox1.Height - s) / 2);
        pictureBox1.Controls.Add(c);
        c.VisibleChanged
        pictureBox1.Invalidate();
    }
