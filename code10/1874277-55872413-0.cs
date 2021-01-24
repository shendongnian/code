        [Service]
        [IntentFilter(new[] { "com.google.firebase.MESSAGING_EVENT" })]
        public class MyFirebaseMessagingService : FirebaseMessagingService
        {
           // private string TAG = "MyFirebaseMsgService";
              public override void OnMessageReceived(RemoteMessage message)
           {
               base.OnMessageReceived(message);
               string messageFrom = message.From;
               string getMessageBody = message.GetNotification().Body;
               SendNotification(message.GetNotification().Body);
           }
        void SendNotification(string messageBody)
        {
            try
            {
                var intent = new Intent(this, typeof(MainActivity));
                intent.AddFlags(ActivityFlags.ClearTop);
                var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
                NotificationCompat.Builder notificationBuilder = new NotificationCompat.Builder(this)
                    .SetSmallIcon(Resource.Drawable.ic_stat_ic_notification)
                    .SetContentTitle("Title")
                    .SetContentText(messageBody)
                    .SetAutoCancel(true)
                    .SetContentIntent(pendingIntent);
                NotificationManagerCompat notificationManager = NotificationManagerCompat.From(this);
                notificationManager.Notify(0, notificationBuilder.Build());
            }
            catch (Exception ex)
            {
            }
           }
         }
