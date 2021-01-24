    [assembly: Dependency(typeof(MainActivity))]
    namespace App18.Droid
    {
    [Activity(Label = "App18", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity,ShowLoading
    {
        private  static Dialog _dialog;
        public void Hide()
        {
            _dialog.Dismiss();
        
        }
        public void Show()
        {
            _dialog.Show();
        }
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
           
            base.OnCreate(savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            init();
        }
        private void init()
        {
            View view = LayoutInflater.From(this).Inflate(Resource.Layout.loading_layout,null);
            _dialog = new Dialog(this);
            _dialog.RequestWindowFeature((int)WindowFeatures.NoTitle);
            _dialog.SetCancelable(false);
            _dialog.SetContentView(view);
        }
    }
