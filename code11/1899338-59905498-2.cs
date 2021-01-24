    XAML:
    <skia:SKCanvasView x:Name="canvas" PaintSurface="OnCanvasViewPaintSurfaceAsync" />
    CODE:
    SKPaintSurfaceEventArgs args;
    // Update canvas through background task    
    async void _timer_Elapsed(object sender, ElapsedEventArgs e)
    {
        // Invalidating surface due to data change
        canvas?.InvalidateSurface();
    }
    
    async void OnCanvasViewPaintSurfaceAsync(object sender, SKPaintSurfaceEventArgs args1)
    {
        args = args1;
        await drawAsync();
    }
    
    public async Task drawAsync()
    {
    
         SKImageInfo info = args.Info;
         SKSurface surface = args.Surface;
         SKCanvas canvas = surface.Canvas;
    }
