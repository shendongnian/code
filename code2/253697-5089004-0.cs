        WebClient wc;
    
        public MainWindow()
        {
            InitializeComponent();
    
            wc = new WebClient();
            wc.DownloadDataAsync(new Uri(@"http://192.168.1.100/FileServer/crypto.bin"));
    
        }
