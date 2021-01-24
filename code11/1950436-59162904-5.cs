    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        foreach (Ellipse ellipse in _ellipses) {
            var center = new PointF(
                ellipse.Rectangle.Left + 0.5f * ellipse.Rectangle.Width,
                ellipse.Rectangle.Top + 0.5f * ellipse.Rectangle.Height);
            var matrix = new Matrix();
            matrix.RotateAt(ellipse.Angle, center);
            e.Graphics.Transform = matrix;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Creates smooth lines.
            e.Graphics.DrawEllipse(Pens.Red, ellipse.Rectangle);
        }
    }
