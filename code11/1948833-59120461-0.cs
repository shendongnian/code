protected override void OnCreate(Bundle bundle)
{
    TabLayoutResource = Resource.Layout.Tabbar;
    ToolbarResource = Resource.Layout.Toolbar;
    base.OnCreate(bundle);
    
    global::Xamarin.Forms.Forms.Init(this, bundle);
    LoadApplication(new App());
    
    // Getting ContentResolver instance
    myContentResolver = this.ContentResolver;
}
And then my GetDeviceId
public String GetDeviceId()
{
    String deviceID = Android.OS.Build.Serial?.ToString();
            
    if (String.IsNullOrEmpty(deviceID) || deviceID.ToUpper() == "UNKNOWN") // Android 9 returns "Unknown"
    {
        ContentResolver myContentResolver = MyApp.Droid.MainActivity.myContentResolver;
        deviceID = Android.Provider.Settings.Secure.GetString(myContentResolver, Android.Provider.Settings.Secure.AndroidId);
    }
    return deviceID;
}
