    public partial class Window3 : Window
    {
        private int i = 0;
        private DispatcherTimer timer
          = new DispatcherTimer(DispatcherPriority.Render); 
        public Window3()
        {
            InitializeComponent();
            timer.Tick += new EventHandler(timer_Tick);
            timer.Interval = new TimeSpan(0, 0, 0, 0, 100);
            timer.IsEnabled = true;
            timer.Start();
        }
        void timer_Tick(object sender, EventArgs e)
        {
            imgChanging.Source
                 = (ImageSource)new BitmapImage(
                       new Uri("Images/Icon" + ((i++ % 100) + 1) + ".png",
                       UriKind.RelativeOrAbsolute));
         }
    }  
