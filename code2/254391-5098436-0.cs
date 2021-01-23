        private PointF[] sourcePoints = GenerateFunctionPoints();
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            e.Graphics.Clear(Color.Black);
            // Wee need to perform transformation on a copy of a points array.
            PointF[] points = (PointF[])sourcePoints.Clone();
            // The way to calculate width and height of our drawing.
            // Of course this operation may be performed outside this method for better performance.
            float drawingWidth = points.Max(p => p.X) - points.Min(p => p.X);
            float drawingHeight = points.Max(p => p.Y) - points.Min(p => p.Y);
            // Calculate the scale aspect we need to apply to points.
            float scaleAspect = Math.Min(ClientSize.Width / drawingWidth, ClientSize.Height / drawingHeight);
            // This matrix transofrmation allow us to scale and translate points so the (0,0) point will be
            // in the center of the screen. X and Y axis will be scaled to fit the drawing on the screen.
            // Also the Y axis will be inverted.
            Matrix matrix = new Matrix();
            matrix.Scale(scaleAspect, -scaleAspect);
            matrix.Translate(drawingWidth / 2, -drawingHeight / 2);
            // Perform a transformation and draw curve using out points.
            matrix.TransformPoints(points);
            e.Graphics.DrawCurve(Pens.Green, points);
        }
        private static PointF[] GenerateFunctionPoints()
        {
            List<PointF> result = new List<PointF>();
            for (double x = -Math.PI; x < Math.PI; x = x + 0.1)
            {
                double y = Math.Sin(x);
                result.Add(new PointF((float)x, (float)y));
            }
            return result.ToArray();
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            Invalidate();
        }
