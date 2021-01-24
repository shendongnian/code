     [Service]
    class MyForegroundService : Service
    {
        public const int SERVICE_RUNNING_NOTIFICATION_ID = 10000;
        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            CreateNotificationChannel();
            string messageBody = "service starting";
           // / Create an Intent for the activity you want to start
           Intent resultIntent = new Intent(this,typeof(Activity1));
           // Create the TaskStackBuilder and add the intent, which inflates the back stack
           TaskStackBuilder stackBuilder = TaskStackBuilder.Create(this);
           stackBuilder.AddNextIntentWithParentStack(resultIntent);
           // Get the PendingIntent containing the entire back stack
           PendingIntent resultPendingIntent = stackBuilder.GetPendingIntent(0, PendingIntentFlags.UpdateCurrent);
           var notification = new Notification.Builder(this, "10111")
            .SetContentIntent(resultPendingIntent)
            .SetContentTitle("Foreground")
            .SetContentText(messageBody)
            .SetSmallIcon(Resource.Drawable.main)
            .SetOngoing(true)
            .Build();
            StartForeground(SERVICE_RUNNING_NOTIFICATION_ID, notification);
             //do you work
            return StartCommandResult.Sticky;
           
        }
        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
        void CreateNotificationChannel()
        {
            if (Build.VERSION.SdkInt < BuildVersionCodes.O)
            {
                // Notification channels are new in API 26 (and not a part of the
                // support library). There is no need to create a notification
                // channel on older versions of Android.
                return;
            }
            var channelName = Resources.GetString(Resource.String.channel_name);
            var channelDescription = GetString(Resource.String.channel_description);
            var channel = new NotificationChannel("10111", channelName, NotificationImportance.Default)
            {
                Description = channelDescription
            };
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
    }
