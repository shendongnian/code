    public class YourActivity: Activity,RateChangeListener
    {
       protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_layout);
            ...
            RateLayout rateLayout = FindViewById<RateLayout>(Resource.Id.ratelayout);
            rateLayout.SetRateChangeListener(this);
        }
       public void RateDeathChange(int rate)
        {
            Toast.MakeText(this, rate + "  star", ToastLength.Short).Show();
        }
        public void RateFateChange(int rate)
        {
            Toast.MakeText(this, rate + "  star", ToastLength.Short).Show();
        }
    }
