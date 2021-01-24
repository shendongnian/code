    public class TilingBrush : XamlCompositionBrushBase
    {
        protected Compositor _compositor => Window.Current.Compositor;
        protected CompositionBrush _imageBrush = null;
        protected IDisposable _surfaceSource = null;
        protected override void OnConnected()
        {
            base.OnConnected();
            if (CompositionBrush == null)
            {
                CreateEffectBrush();
                Render();
            }
        }
        protected override void OnDisconnected()
        {
            base.OnDisconnected();
            this.CompositionBrush?.Dispose();
            this.CompositionBrush = null;
            ClearResources();
        }
        private void ClearResources()
        {
            _imageBrush?.Dispose();
            _imageBrush = null;
            _surfaceSource?.Dispose();
            _surfaceSource = null;
        }
        private void UpdateBrush()
        {
            if (CompositionBrush != null && _imageBrush != null)
            {
                ((CompositionEffectBrush)CompositionBrush).SetSourceParameter(nameof(BorderEffect.Source), _imageBrush);
            }
        }
        protected ICompositionSurface CreateSurface()
        {
            double width = 20;
            double height = 20;
            CanvasDevice device = CanvasDevice.GetSharedDevice();
            var graphicsDevice = CanvasComposition.CreateCompositionGraphicsDevice(_compositor, device);
            CompositionSurfaceBrush drawingBrush = _compositor.CreateSurfaceBrush();
            var drawingSurface = graphicsDevice.CreateDrawingSurface(
                new Size(width, height),
                DirectXPixelFormat.B8G8R8A8UIntNormalized,
                DirectXAlphaMode.Premultiplied);
            /* Create Drawing Session is not thread safe - only one can ever be active per app */
            using (var ds = CanvasComposition.CreateDrawingSession(drawingSurface))
            {
                ds.Clear(Colors.Transparent);
                ds.DrawCircle(new Vector2(10, 10), 5, Colors.Black, 3);
            }
        }
        private void Render()
        {
            ClearResources();
            try
            {
                var src = CreateSurface();
                _surfaceSource = src as IDisposable;
                var surfaceBrush = _compositor.CreateSurfaceBrush(src);
                surfaceBrush.VerticalAlignmentRatio = 0.0f;
                surfaceBrush.HorizontalAlignmentRatio = 0.0f;
                surfaceBrush.Stretch = CompositionStretch.None;
                _imageBrush = surfaceBrush;
                UpdateBrush();
            }
            catch
            {
                // no image for you, soz.
            }
        }
        private void CreateEffectBrush()
        {
            using (var effect = new BorderEffect
            {
                Name = nameof(BorderEffect),
                ExtendY = CanvasEdgeBehavior.Wrap,
                ExtendX = CanvasEdgeBehavior.Wrap,
                Source = new CompositionEffectSourceParameter(nameof(BorderEffect.Source))
            })
            using (var _effectFactory = _compositor.CreateEffectFactory(effect))
            {               
                this.CompositionBrush = _effectFactory.CreateBrush();
            }
        }
    }
