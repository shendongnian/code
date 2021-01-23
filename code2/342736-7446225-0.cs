    Rectangle selectedRect = new Rectangle(16, 16, 64, 28);
    private void Form1_Load(object sender, EventArgs e)
    {
      panel1.AutoScrollMinSize = new Size(panel1.ClientRectangle.Width - SystemInformation.VerticalScrollBarWidth, 1200);
    }
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
      e.Graphics.TranslateTransform(panel1.AutoScrollPosition.X, panel1.AutoScrollPosition.Y);
      e.Graphics.FillRectangle(Brushes.Red, selectedRect);
    }
    private void panel1_Scroll(object sender, ScrollEventArgs e)
    {
      panel1.Invalidate();
    }
