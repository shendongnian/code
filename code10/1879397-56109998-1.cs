        [BroadcastReceiver]
    public class WifiScanReceiver : BroadcastReceiver
    {
        private MainActivity mainActivity;
        public WifiScanReceiver() { }
        public WifiScanReceiver(MainActivity mainActivity)
        {
            this.mainActivity = mainActivity;
        }
        public override async void OnReceive(Context context, Intent intent)
        {
            var mainActivity = (MainActivity)context;
            var wifiManager = (WifiManager)mainActivity.GetSystemService(Context.WifiService);
            var message = string.Join("\r\n", wifiManager.ScanResults
                .Select(r => $"{r.Ssid} - {r.Bssid}"));
            mainActivity.DisplayText(message);
            await Task.Delay(TimeSpan.FromSeconds(1));
            wifiManager.StartScan();
           
          //  Toast.MakeText(context, "Received intent!", ToastLength.Short).Show();
          
        }
    }
