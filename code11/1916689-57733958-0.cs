       protected override void OnCreate(Bundle savedInstanceState)
        {
            Current = this;
            //TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
            Xamarin.Forms.Forms.Init(this, savedInstanceState);
      
            //allowing the device to change the screen orientation based on the rotation
            MessagingCenter.Subscribe<VideoPlayerView>(this, "allowLandScape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Landscape;
            });
            //during page close setting back to portrait
            MessagingCenter.Subscribe<VideoPlayerView>(this, "preventLandScape", sender =>
            {
                RequestedOrientation = ScreenOrientation.Portrait;
            });
            LoadApplication(new App());
        }
