        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            DeviceService.StoragePath = StoragePath;
        }
        private string StoragePath => ApplicationData.Current.LocalFolder.Path;
