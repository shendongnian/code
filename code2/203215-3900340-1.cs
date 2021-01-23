    public partial class MainWindow : Window
      {
        DispatcherTimer _timer = new DispatcherTimer();
        RenderTargetBitmap _renderSurface = 
          new RenderTargetBitmap(100, 100, 96, 96, PixelFormats.Pbgra32);
        Random _rnd = new Random();
    
        public MainWindow()
        {
          InitializeComponent();
    
          _timer = new DispatcherTimer();
          _timer.Interval = TimeSpan.FromMilliseconds(100);
          _timer.Tick += new EventHandler(_timer_Tick);
          _timer.Start();      
        }
            
        void _timer_Tick(object sender, EventArgs e)
        {
          DrawingVisual visual = new DrawingVisual();
          DrawingContext context = visual.RenderOpen();
          int value = _rnd.Next(40);
          context.DrawEllipse(
            new SolidColorBrush(Colors.Red), 
            new Pen(new SolidColorBrush(Colors.Black), 1), 
            new Point(value, value), value, value);
          context.Close();
    
          _renderSurface.Render(visual);
          frameImage.Source = _renderSurface;
        }    
      }
