    public Size SizeAfterRotation(Size sz, float angle)
    {
        var m = new Matrix();
        m.Rotate(angle);
        var pts = new[]
                      {
                          new Point(sz.Width, sz.Height),
                          new Point(sz.Width, 0)
                      };
        m.TransformPoints(pts);
        return new Size(
            Math.Max(Math.Abs(pts[0].X), Math.Abs(pts[1].X)),
            Math.Max(Math.Abs(pts[0].Y), Math.Abs(pts[1].Y)));
    }
