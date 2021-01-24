    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        foreach (Ellipse ellipse in _ellipses) {
            var matrix = new Matrix();
            matrix.RotateAt(ellipse.Angle, ellipse.Center);
            e.Graphics.Transform = matrix;
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias; // Creates smooth lines.
            e.Graphics.DrawEllipse(Pens.Red, ellipse.Rectangle);
        }
    }
