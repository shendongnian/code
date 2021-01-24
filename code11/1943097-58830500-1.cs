    private void Form1_Paint(object sender, PaintEventArgs e)
    {
        e.Graphics.Clear(Color.FromArgb(0, 0, 40));
        e.Graphics.DrawEllipse(new Pen(Color.FromArgb(0, 150, 0)), new Rectangle(0, 0, this.ClientSize.Width-1, this.ClientSize.Height-1));
    }
