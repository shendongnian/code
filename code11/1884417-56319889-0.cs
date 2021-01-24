        protected override void OnCreate(Bundle savedInstanceState) {
            base.OnCreate(savedInstanceState);
            // Get Screen Dimensions
            var dm = Resources.DisplayMetrics;
            var widthDP = dm.WidthPixels / dm.Density;
            var heightDP = dm.HeightPixels / dm.Density;
            Android.Util.Log.Info("MyApp", $"Screen Width x Screen Height = {widthDP}dp X {heightDP}dp");
            // Add 10 Buttons in a ScrollView
            var sv = new ScrollView(this);            
            var ll = new LinearLayout(this) { Orientation = Android.Widget.Orientation.Vertical };
            sv.AddView(ll);
            for (int i = 0; i < 10; i++) {
                var btn = new Button(this);
                btn.SetBackgroundColor(Color.Blue);
                btn.Text = $"Button #{i+1}";
                btn.Tag = i+1;
                btn.Click += (sender, e) => {
                    Android.Util.Log.Info("MyApp", $"Button # {btn.Tag} + Clicked!");
                };
                // Make each button 50% of the total screen width and 20% of the *total* screen height
                var lp = new LinearLayout.LayoutParams(Convert.ToInt32(widthDP * .50), Convert.ToInt32(heightDP * .20));
                lp.SetMargins(0, 10, 0, 0);     // Top margin of 10
                btn.LayoutParameters = lp;
                ll.AddView(btn);
            }
            SetContentView(sv);
        }
