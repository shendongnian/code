    public override void Draw(Graphics graphics) {
      if (this.bitmap != null) {
        Graphics g = Graphics.FromImage(this.bitmap);
        g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
        g.DrawEllipse(new Pen(this.Color, this.PenSize), startPoint.X, startPoint.Y,
                             this.PenSize, this.PenSize);
        graphics.DrawImage(this.bitmap, 0, 0);
      }
    }
