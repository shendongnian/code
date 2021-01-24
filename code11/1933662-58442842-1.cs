     protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
           
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
           
            LoadApplication(new App());
           Window.SetStatusBarColor(Android.Graphics.Color.Argb(255, 0, 0, 0)); //here
        }
