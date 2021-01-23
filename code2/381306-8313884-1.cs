    private void button1_Click(object sender, EventArgs e) {
      using (Graphics g = Graphics.FromImage(imag)) {
        g.DrawLine(Pens.Red, new Point(0, 0), new Point(32, 32));
      }
      drawP.Invalidate();
    }
