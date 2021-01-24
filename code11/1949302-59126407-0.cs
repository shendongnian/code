    protected override void OnResume()
        {
            base.OnResume();
            Toast.MakeText(this, "1111", ToastLength.Short).Show();
            Handler handler = new Handler();
            handler.PostDelayed(() => {
                StartActivity(typeof(MainActivity));
                OverridePendingTransition(0, 0);
            }, 3000);
        }
