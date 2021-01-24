    [assembly: Dependency(typeof(demo2.Droid.MainActivity))]
     namespace demo2.Droid
     {
    [Activity(Label = "demo2", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,IStatusBarColor
    {
      
        public static Context context;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
          
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            LoadApplication(new App());
          
        }
       
        public void changestatuscolor(string color)
        {
            if (Build.VERSION.SdkInt >= BuildVersionCodes.Lollipop)
            {
                var c = MainActivity.context as FormsAppCompatActivity;
                c?.RunOnUiThread(() => c.Window.SetStatusBarColor(Android.Graphics.Color.ParseColor(color)));
            }
        }
        protected override void OnResume()
        {
            context = this;
            base.OnResume();
        }
    }
