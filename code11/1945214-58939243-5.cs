    public MainPage()
    {
        InitializeComponent();
        Device.BeginInvokeOnMainThread(() => AskPermission());
        CheckPermissionStatusRepeatedly();
        ...
    }
    async void AskPermission()
    {
        var status = await CrossPermissions.Current.CheckPermissionStatusAsync(Permission.Location);
        if (status != PermissionStatus.Granted)
        {
            await Application.Current.MainPage.DisplayAlert("Permission Request", "This app needs to access device location. Please allow access for location.", "Ok");
            try
            {
                await CrossPermissions.Current.RequestPermissionsAsync(new[] { Permission.Location });
            }
            catch (Exception ex)
            {
                Location.Text = "Error: " + ex;
            }                
        }
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
        Location.Text = "Lat: " + location.Latitude + " Long: " + location.Longitude;
    }
