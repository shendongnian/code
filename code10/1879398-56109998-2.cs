         [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        TextView txtScanResults;
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            RegisterReceiver(new WifiScanReceiver(this), new IntentFilter(WifiManager.ScanResultsAvailableAction));
            ((Android.Net.Wifi.WifiManager)GetSystemService(WifiService)).StartScan();
            txtScanResults = FindViewById<TextView>(Resource.Id.textView1);
        }
        public void DisplayText(string text)
        {
            txtScanResults.Text = "Wifi networks: \r\n" + text;
        }
        protected override void OnResume()
        {
            base.OnResume();
          
            
        }
     }
