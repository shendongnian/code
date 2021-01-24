     public MainPage()
        {
            InitializeComponent();
            webView.Source = "https://xamarin.swappsdev.net/";
        }
        protected override void OnAppearing()
        {
            base.OnAppearing();
            RunTimePermission();
        }
        public async void RunTimePermission()
        {
            var status = PermissionStatus.Unknown;
            status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Camera);
            if (status != PermissionStatus.Granted)
            {
                status = await Utils.CheckPermissions(Permission.Camera);
            }
        }
