    public MainPage()
    {
        InitializeComponent();
        CheckPermissionStatusRepeatedly();
        ...
    }
    void CheckPermissionStatusRepeatedly()
    {
        Timer timer = null;
        timer = new Timer(new TimerCallback(async delegate
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
            if (status != PermissionStatus.Granted)
                Debug.WriteLine("Still permission is not Granted");
            else
            {
                Debug.WriteLine("Now permision is Granted, Hence calling GetLocation()");
                Device.BeginInvokeOnMainThread(() => GetLocation());                    
                timer.Dispose();
            }
        }), "test", 1000, 1000);
    }
    async void GetLocation()
    {
        Location location;
        location = await Geolocation.GetLastKnownLocationAsync();
        Location.Text = location.Latitude.ToString();
    }
