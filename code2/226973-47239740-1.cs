    //90 degrees
    e.Graphics.TranslateTransform(sz.Width, 0);
    e.Graphics.RotateTransform(90);
    e.Graphics.DrawString(Text, this.Font, Brushes.Black,
      new RectangleF(sz.ToPointF().Y, sz.ToPointF().X, sz.Height, sz.Width), format);
    e.Graphics.ResetTransform();
    //180 degrees
    e.Graphics.TranslateTransform(sz.Width, sz.Height);
    e.Graphics.RotateTransform(180 this.Font, Brushes.Black,
      new RectangleF(-sz.ToPointF().X, -sz.ToPointF().Y, sz.Width, sz.Height), format);
    e.Graphics.ResetTransform();
    //270 degrees
    e.Graphics.TranslateTransform(0, sz.Height);
    e.Graphics.RotateTransform(270);
    e.Graphics.DrawString(Text, this.Font, Brushes.Black,
      new RectangleF(-sz.ToPointF().Y, sz.ToPointF().X, sz.Height, sz.Width), format);
    //0 = 360 degrees
    e.Graphics.TranslateTransform(0, 0);
    e.Graphics.RotateTransform(0);
    e.Graphics.DrawString(Text, this.Font, Brushes.Black,
      new RectangleF(sz.ToPointF().X, sz.ToPointF().Y, sz.Width, sz.Height), format);
    e.Graphics.ResetTransform();
