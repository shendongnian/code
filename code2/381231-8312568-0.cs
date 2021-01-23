    Bitmap bmp = new Bitmap(500, 500);
    private void button1_Click(object sender, EventArgs e) {
      using (Graphics g = Graphics.FromImage(bmp)) {
        g.SmoothingMode = SmoothingMode.AntiAlias;
        g.Clear(Color.White);
        g.FillEllipse(Brushes.Red, new Rectangle(10, 10, 32, 32));
      }
      panel1.Invalidate();
    }
    private void panel1_Paint(object sender, PaintEventArgs e) {
      e.Graphics.DrawImage(bmp, new Point(0, 0));
    }
