    protected override void OnMouseDown(MouseEventArgs e) {
      base.OnMouseDown(e);
      rcSelect = new Rectangle(e.Location, new Size(10, 10));
    }
    protected override void OnMouseUp(MouseEventArgs e) {
      base.OnMouseUp(e);
      int rcLeft = Math.Min(e.X, rcSelect.X);
      int rcTop = Math.Min(e.Y, rcSelect.Y);
      int rcWidth = Math.Max(e.X, rcSelect.Left) - Math.Min(e.X, rcSelect.Left);
      int rcHeight = Math.Max(e.Y, rcSelect.Top) - Math.Min(e.Y, rcSelect.Top);
      rcSelect = new Rectangle(new Point(rcLeft, rcTop), new Size(rcWidth, rcHeight));
      toolStrip1.Location = new Point(
        Math.Max(0, 
          Math.Min(this.ClientSize.Width - toolStrip1.Width,
                   rcSelect.Right - toolStrip1.Width)
        ),
        rcSelect.Bottom > this.ClientSize.Height ?
          rcSelect.Top - toolStrip1.Height :
          rcSelect.Bottom
      );
      toolStrip2.Location = new Point(
        rcSelect.Right > this.ClientSize.Width ?
          rcSelect.Left - toolStrip2.Width :
          rcSelect.Right,
        Math.Max(0, 
          Math.Min(this.ClientSize.Height - toolStrip2.Height,
                   rcSelect.Bottom - toolStrip2.Height)
        )
      );
    }
