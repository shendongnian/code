    private void Form1_Paint(object sender, PaintEventArgs e) {
      // using your CreateGraphics:
      Pen pen = new Pen(Color.Black);
      for (int i = 0; i < this.ClientSize.Height; i++) {
        g.DrawLine(pen, 100, i, 50, i);
      }
      // using e.Graphics:
      for (int i = 0; i < this.ClientSize.Height; i++) {
        e.Graphics.DrawLine(Pens.Black, 200, i, 250, i);
      }
    }
