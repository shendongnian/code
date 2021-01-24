        //the notification class
        public class CustomNotification
        {
            public string _noteType { get; set; }
            public string _noteText { get; set; }
            public string _noteLink { get; set; }
            public int _noteIndex { get; set; }
        }
        //this has to be in MainActivity
        protected override void OnNewIntent(Intent intent)
        {
            string url = "";
            base.OnNewIntent(intent);
            if (intent != null)
            {
                url = intent.Extras.GetString("URL");
            }
            try
            {
                switch (_viewPager.CurrentItem)
                {
                    case 0:
                        _fm1.LoadCustomUrl(url);
                        break;
                    case 1:
                        _fm2.LoadCustomUrl(url);
                        break;
                    case 2:
                        _fm3.LoadCustomUrl(url);
                        break;
                    case 3:
                        _fm4.LoadCustomUrl(url);
                        break;
                    case 4:
                        _fm5.LoadCustomUrl(url);
                        break;
                }
            }
            catch
            {
            }
            
        }
        public void SendNotifications(List<CustomNotification> notificationList)
        {
            try
            {
                var _ctx = Android.App.Application.Context;
                int _noteCount = 0;
                foreach (var note in notificationList)
                {
                    var resultIntent = new Intent(_ctx, typeof(MainActivity));
                    var valuesForActivity = new Bundle();
                    valuesForActivity.PutInt(MainActivity.COUNT_KEY, _count);
                    MainActivity._NotificationURLList.Add(note._noteLink);
                    valuesForActivity.PutInt("Count", _noteCount);
                    valuesForActivity.PutString("URL", note._noteLink);
                    resultIntent.PutExtras(valuesForActivity);
                    //var resultPendingIntent = PendingIntent.GetActivity(_ctx, 0, resultIntent, PendingIntentFlags.UpdateCurrent);
                    //set to unique ID per Leo Zhu - MSFT
                    var resultPendingIntent = PendingIntent.GetActivity(_ctx, MainActivity.NOTIFICATION_ID, resultIntent, PendingIntentFlags.UpdateCurrent);
                    resultIntent.AddFlags(ActivityFlags.SingleTop);
                    var builder = new Android.Support.V4.App.NotificationCompat.Builder(_ctx, MainActivity.CHANNEL_ID)
                                  .SetAutoCancel(true) // Dismiss the notification from the notification area when the user clicks on it
                                  .SetContentIntent(resultPendingIntent) // Start up this activity when the user clicks the intent.
                                  .SetContentTitle(note._noteType) // Set the title
                                  .SetNumber(_count) // Display the count in the Content Info
                                  //xamarin was all whacked out so I had to set this static int from ctrl + F (resource) in resourcedesigner.cs
                                  .SetSmallIcon(2130837590) // This is the icon to display
                                  .SetContentText(note._noteText);
                    MainActivity.NOTIFICATION_ID++;
                    // Finally, publish the notification:
                    var notificationManager = Android.Support.V4.App.NotificationManagerCompat.From(_ctx);
                    notificationManager.Notify(MainActivity.NOTIFICATION_ID, builder.Build());
                    _count++;
                    _noteCount++;
                    //I think if the notification count gets too high android kills the app?  I set this very high just in case
                    if (_count >= 300)
                    {
                        _count = 0;
                        return;
                    }
                }
            }
            catch
            {
            }
        }
