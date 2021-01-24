    protected override void OnCreate(Bundle savedInstanceState) {
        base.OnCreate(savedInstanceState);
        SetContentView(Resource.Layout.main_layout);
        var btn = FindViewById<Button>(Resource.Id.btnLoadSenderActivity);
        btn.Click += (sender, e) => { StartActivity(typeof(SenderActivity)); };
    }
    
    protected override void OnResume() {
        base.OnResume();
        Intent intent = Intent;
        string sharedText = intent.GetStringExtra("KEY");
        if (sharedText != null) Toast.MakeText(this, sharedText, ToastLength.Short).Show();
    }
