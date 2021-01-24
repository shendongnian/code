            [DllImport("user32.dll")]
            static extern void ClipCursor(ref System.Drawing.Rectangle rect);
    
            [DllImport("user32.dll")]
            static extern void ClipCursor(IntPtr rect);   
          
            public MainWindow()
            {
                InitializeComponent();
                this.DataContext = this;
                this.Loaded += MainWindow_Loaded;
            }
    
            void MainWindow_Loaded(object sender, RoutedEventArgs e)
            {
                System.Drawing.Rectangle r = new System.Drawing.Rectangle(0, 0, 0, 0);
                ClipCursor(ref r);
            }
