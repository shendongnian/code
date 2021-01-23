    [Activity (MainLauncher = true, Theme = "@style/Theme.Splash", NoHistory = true)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate (Bundle bundle)
        {
            base.OnCreate (bundle);
            // Create your async task here...
            StartActivity (typeof (Activity1));
        }
    }
