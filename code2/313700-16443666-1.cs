    namespace Mono.Droid
    {
        [Activity(
            Label = "Splash Activity",
            MainLauncher = true, 
            Theme = "@android:style/Theme.Black.NoTitleBar", 
            Icon = "@drawable/icon",
            NoHistory = false)]
        public class SplashActivity : Activity
        {
            protected override void OnCreate(Bundle savedInstanceState)
            {
                base.OnCreate(savedInstanceState);
                SetContentView(Resource.Layout.SplashLayout);
                Thread initializeDataWorker = new Thread(new ThreadStart(InitializeData));
                initializeDataWorker.Start();
            }        
            private void InitializeData()
            {
                // create a DB
                // get some data from web-service
                // ...
                StartActivity(typeof(MainActivity));
            }
        }
    }
