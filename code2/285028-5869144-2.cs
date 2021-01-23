        private System.Threading.Timer timer;
        public MainWindow()
        {
            InitializeComponent();
            timer = new System.Threading.Timer(OnTimerEllapsed, new object(), 0, 2000);
        }
        private void OnTimerEllapsed(object state)
        {
            if (!this.Dispatcher.CheckAccess())
            {
                this.Dispatcher.Invoke(new Action(LoadImages));
            }
        }
        private bool switcher;
        private void LoadImages()
        {
            string stringUri = switcher ? @"D:\\connect2-1.gif" :
                                          @"D:\\connect3-1.gif";
            this.Image_LoadImage.Source = new BitmapImage(new Uri(stringUri));
            switcher = !switcher;
        }
