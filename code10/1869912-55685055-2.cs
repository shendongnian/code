    [DllImport("user32.dll")]
        static extern void ClipCursor(ref System.Drawing.Rectangle rect);
    
        [DllImport("user32.dll")]
        static extern void ClipCursor(IntPtr rect);
    
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            this.Loaded += MainWindow_Loaded;
            this.MouseMove += Window_MouseMove;
        }
    
        void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Maximized;
            HideMouse();
        }
        private void Window_MouseMove(object sender, MouseEventArgs e)
        {
            HideMouse();
        }
    
        private void HideMouse()
        {
            System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, 0, 0);
            ClipCursor(ref r);
        }
