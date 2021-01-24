     public static MainActivity macvivity;
       
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;
            base.OnCreate(savedInstanceState);
          
            macvivity = this;    
       
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);          
            LoadApplication(new App());
         
        }
