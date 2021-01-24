    private Point mousePosition = Point.Empty;
    private float lineSize = 100.0f;
    private int shadowDistance = 16;
    private void panel1_Paint(object sender, PaintEventArgs e)
    {
        using (var path = new GraphicsPath(FillMode.Winding))
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.PixelOffsetMode = PixelOffsetMode.Half;
            PointF[] arrowPoints = new PointF[] {
                mousePosition,
                new PointF (mousePosition.X - 20f, mousePosition.Y + 10f),
                new PointF (mousePosition.X - 20f, mousePosition.Y + 3f),
                new PointF (mousePosition.X - lineSize, mousePosition.Y + 3f),
                new PointF (mousePosition.X - lineSize, mousePosition.Y - 3f),
                new PointF (mousePosition.X - 20f, mousePosition.Y - 3f),
                new PointF (mousePosition.X - 20f, mousePosition.Y - 10f)
            };
            path.AddLines(arrowPoints);
            using (var brush = new PathGradientBrush(path.PathPoints, WrapMode.Clamp))
            {
                var blend = new ColorBlend()
                {
                    Colors = new Color[] { Color.Transparent,
                                           Color.FromArgb(180, Color.DimGray),
                                           Color.FromArgb(180, Color.DimGray) },
                    Positions = new float[] { 0.0f, 0.2f, 1.0f }
                };
                brush.FocusScales = new PointF(0.3f, 1.0f);
                brush.InterpolationColors = blend;
                e.Graphics.FillPath(brush, path);
            }
            using (var mx = new Matrix())
            {
                mx.Translate(-shadowDistance, -shadowDistance);
                e.Graphics.Transform = mx;
                e.Graphics.FillPath(Brushes.Red, (GraphicsPath)path.Clone());
            }
        }
    }
