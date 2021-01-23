    private Color[,] _Colors = new Color[30, 30];
    private void panel1_Paint(object sender, PaintEventArgs e) {
      int left = 0;
      int top = 0;
      for (int y = 0; y < 30; y++) {
        left = 0;
        for (int x = 0; x < 30; x++) {
          Rectangle r = new Rectangle(left, top, 20, 20);
          using (SolidBrush sb = new SolidBrush(_Colors[x, y]))
            e.Graphics.FillRectangle(sb, r);
          ControlPaint.DrawBorder3D(e.Graphics, r, Border3DStyle.Raised, Border3DSide.Left | Border3DSide.Top | Border3DSide.Right | Border3DSide.Bottom);
          left += 20;
        }
        top += 20;
      }
    }
    private void panel1_MouseDown(object sender, MouseEventArgs e) {
      if (e.Button == MouseButtons.Left) {
        int left = 0;
        int top = 0;
        for (int y = 0; y < 30; y++) {
          left = 0;
          for (int x = 0; x < 30; x++) {
            Rectangle r = new Rectangle(left, top, 20, 20);
            if (r.Contains(e.Location)) {
              _Colors[x, y] = Color.Red;
              panel1.Invalidate();
            }
            left += 20;
          }
          top += 20;
        }
      }
    }
