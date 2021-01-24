    private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Fill,
                Color = SKColors.White,
                StrokeWidth = 1,
            };
            SKPath path = new SKPath();
            path.MoveTo(0, info.Height / 2);
            path.LineTo(info.Width, info.Height * 3 / 4);
            path.LineTo(info.Width, info.Height / 4);
            path.Close();
            canvas.DrawPath(path, paint);
        }
    }
