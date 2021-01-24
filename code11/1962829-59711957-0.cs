    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 3,
                PathEffect = SKPathEffect.CreateDash(new float[] { 10, 10 }, 20)
            };
            SKPath path = new SKPath();
            path.MoveTo(info.Width / 2, 0);
            path.LineTo(info.Width / 2, info.Height);
            canvas.DrawPath(path, paint);
        }
