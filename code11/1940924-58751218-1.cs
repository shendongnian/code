    [assembly: Xamarin.Forms.Dependency(typeof(MySmsReader))]
    namespace ScanDemo.Droid
    {
     public class MySmsReader : ISmsReader
    {
        public void GetSmsInbox()
        {
            IntentFilter filter = new IntentFilter();
            filter.AddAction("android.provider.Telephony.SMS_RECEIVED");
            SmsBroadcastRceiver receiver = new SmsBroadcastRceiver();
            Application.Context.RegisterReceiver(receiver, filter);
           // RegisterReceiver(receiver, filter);
        }
      }
    }
