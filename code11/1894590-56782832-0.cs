     protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);        
            SetContentView(Resource.Layout.layout1);
            View toolBar = new ToolBarHeader(this);
            SupportActionBar.SetCustomView(toolBar, new Android.Support.V7.App.ActionBar.LayoutParams(Android.Support.V7.App.ActionBar.LayoutParams.MatchParent,Android.Support.V7.App.ActionBar.LayoutParams.MatchParent));
            SupportActionBar.SetDisplayShowCustomEnabled(true);
            ((Android.Support.V7.Widget.Toolbar)SupportActionBar.CustomView.Parent).SetContentInsetsAbsolute(0, 0);
        }
