    [BroadcastReceiver(Enabled = true, Exported = true)]
    [IntentFilter(new[] { "android.provider.Telephony.SMS_RECEIVED" })]
    public class SmsBroadcastRceiver : BroadcastReceiver
    {
        public SmsBroadcastRceiver()
        {
        }
 
        public override void OnReceive(Context context, Intent intent)
        {
            var msgs = Telephony.Sms.Intents.GetMessagesFromIntent(intent);
            List<string> msgList = new List<string>();
            foreach (var msg in msgs)
            {
                msgList.Add(msg.DisplayMessageBody);
             
            }
            MessagingCenter.Send<List<string>>(msgList, "MyMessage");
        }
    }
