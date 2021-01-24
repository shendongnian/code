    GraphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(Compositor, CanvasDevice.GetSharedDevice());                
    
    var roudRectMaskSurface = GraphicsDevice.CreateDrawingSurface(new Size(SurfaceWidth + BlurMargin * 2, SurfaceHeight + BlurMargin * 2), DirectXPixelFormat.B8G8R8A8UIntNormalized, DirectXAlphaMode.Premultiplied);
    using (var ds = CanvasComposition.CreateDrawingSession(roudRectMaskSurface))
    {
        ds.Clear(Colors.Transparent);
        ds.FillRoundedRectangle(new Rect(BlurMargin, BlurMargin, roudRectMaskSurface.Size.Width + BlurMargin, roudRectMaskSurface.Size.Height + BlurMargin), YourRadius, YourRadius, Colors.Black);
    }
    var rectangleMask = Compositor.CreateSurfaceBrush(roudRectMaskSurface);
