    [DesignTimeVisible(true)]
    public class FlyingImageBackgroundSkia : ContentView
    {
        public static readonly BindableProperty IsActiveProperty =
            BindableProperty.Create(
                nameof(IsActive),
                typeof(bool),
                typeof(FlyingImageBackground),
                default(bool),
                BindingMode.TwoWay,
                propertyChanged: OnPageActivenessChanged);
    
        private SKCanvasView canvasView;
        private SKBitmap resourceBitmap;
        private Stopwatch stopwatch = new Stopwatch();
    
        // consider making these bindable props
        private float percentComplete;
        private float imageSize = 40;
        private float columnSpacing = 100;
        private float rowSpacing = 100;
        private float framesPerSecond = 60;
        private float cycleTime = 1; // in seconds, for a single column
    
        public FlyingImageBackgroundSkia()
        {
            this.canvasView = new SKCanvasView();
            this.canvasView.PaintSurface += OnCanvasViewPaintSurface;
            this.Content = this.canvasView;
    
            string resourceID = "XamarinTestProject.Resources.Images.fireTruck.png";
            Assembly assembly = GetType().GetTypeInfo().Assembly;
    
            using (Stream stream = assembly.GetManifestResourceStream(resourceID))
            {
                this.resourceBitmap = SKBitmap.Decode(stream);
            }
        }
    
        ~FlyingImageBackgroundSkia() => this.resourceBitmap.Dispose();
    
        public bool IsActive
        {
            get => (bool)GetValue(IsActiveProperty);
            set => SetValue(IsActiveProperty, value);
        }
    
        private static async void OnPageActivenessChanged(BindableObject bindable, object oldValue, object newValue)
        {
            var control = (FlyingImageBackgroundSkia)bindable;
            await control.AnimationLoop();
        }
    
        private async Task AnimationLoop()
        {
            this.stopwatch.Start();
    
            while (IsActive)
            {
                this.percentComplete = (float)(this.stopwatch.Elapsed.TotalSeconds % this.cycleTime) / this.cycleTime; // always between 0 and 1
                this.canvasView.InvalidateSurface(); // trigger redraw
                await Task.Delay(TimeSpan.FromSeconds(1.0 / this.framesPerSecond)); // non-blocking
            }
    
            this.stopwatch.Stop();
        }
    
        private void OnCanvasViewPaintSurface(object sender, SKPaintSurfaceEventArgs args)
        {
            SKImageInfo info = args.Info;
            SKSurface surface = args.Surface;
            SKCanvas canvas = surface.Canvas;
    
            canvas.Clear();
    
            var xPositions = Enumerable.Range(0, info.Width + (int)this.columnSpacing).Where(x => x % (int)this.columnSpacing == 0).ToList();
            xPositions.Insert(0, -(int)this.columnSpacing);
    
            var yPositions = Enumerable.Range(0, info.Height + (int)this.rowSpacing).Where(x => x % (int)this.rowSpacing == 0).ToList();
            yPositions.Insert(0, -(int)this.rowSpacing);
    
            if (this.resourceBitmap != null)
            {
                foreach (var xPos in xPositions)
                {
                    var xPosNow = xPos + (this.rowSpacing * this.percentComplete);
                    foreach (var yPos in yPositions)
                    {
                        canvas.DrawBitmap(
                            this.resourceBitmap,
                            new SKRect(xPosNow, yPos, xPosNow + this.imageSize, yPos + this.imageSize));
                    }
                }
            }
        }
    }
