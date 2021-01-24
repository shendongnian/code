    public class SimpleCirclePage : ContentPage{
        float radius = 0;
        public SimpleCirclePage()
        {
            SKCanvasView canvasView = new SKCanvasView();
            canvasView.PaintSurface += OnCanvasViewPaintSurface;
            this.Content = canvasView;
            Device.StartTimer(TimeSpan.FromMilliseconds(4000), () =>
            {
                radius= 100;
                canvasView.InvalidateSurface();
                return false;
            });
        }
         void  OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
            canvas.Clear();
            SKPaint paint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = Color.Red.ToSKColor(),
                StrokeWidth = 10
            };
            canvas.DrawCircle(info.Width / 3, info.Height / 2, 100, paint);
            // I want to draw the second circle after some delay.
            canvas.DrawCircle(info.Width / 3, info.Height / 3, radius, paint);
        }
    }
