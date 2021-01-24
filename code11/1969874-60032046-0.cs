    [Service(Enabled = true)]
    public class MyService : Service
    {
        private Handler handler;
        private Action runnable;
        private bool isStarted;
        private int DELAY_BETWEEN_LOG_MESSAGES = 5000;
        private int NOTIFICATION_SERVICE_ID = 1001;
        private int NOTIFICATION_AlARM_ID = 1002;
        private string NOTIFICATION_CHANNEL_ID = "1003";
        private string NOTIFICATION_CHANNEL_NAME = "MyChannel";
        public override void OnCreate()
        {
            base.OnCreate();
            handler = new Handler();
            
            //here is what you want to do always, i just want to push a notification every 5 seconds here
            runnable = new Action(() =>
            {
               if (isStarted)
                {
                    DispatchNotificationThatAlarmIsGenerated("I'm running");
                    handler.PostDelayed(runnable, DELAY_BETWEEN_LOG_MESSAGES);
                }
            });
        }
        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            if (isStarted)
            {
                // service is already started
            }
            else
            {
                CreateNotificationChannel();
                DispatchNotificationThatServiceIsRunning();
                handler.PostDelayed(runnable, DELAY_BETWEEN_LOG_MESSAGES);
                isStarted = true;
            }
            return StartCommandResult.Sticky;
        }
        public override void OnTaskRemoved(Intent rootIntent)
        {
            //base.OnTaskRemoved(rootIntent);
        }
        public override IBinder OnBind(Intent intent)
        {
            // Return null because this is a pure started service. A hybrid service would return a binder that would
            // allow access to the GetFormattedStamp() method.
            return null;
        }
        public override void OnDestroy()
        {
            // Stop the handler.
            handler.RemoveCallbacks(runnable);
            // Remove the notification from the status bar.
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Cancel(NOTIFICATION_SERVICE_ID);
            isStarted = false;
            base.OnDestroy();
        }
        private void CreateNotificationChannel()
        {
            //Notification Channel
            NotificationChannel notificationChannel = new NotificationChannel(NOTIFICATION_CHANNEL_ID, NOTIFICATION_CHANNEL_NAME, NotificationImportance.Max);
            notificationChannel.EnableLights(true);
            notificationChannel.EnableVibration(true);
            notificationChannel.SetVibrationPattern(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 });
            NotificationManager notificationManager = (NotificationManager)this.GetSystemService(Context.NotificationService);
            notificationManager.CreateNotificationChannel(notificationChannel);
        }
        //start a foreground notification to keep alive 
        private void DispatchNotificationThatServiceIsRunning()
        {
            NotificationCompat.Builder builder = new NotificationCompat.Builder(this, NOTIFICATION_CHANNEL_ID)
                   .SetDefaults((int)NotificationDefaults.All)
                   .SetSmallIcon(Resource.Drawable.Icon)
                   .SetVibrate(new long[] { 100, 200, 300, 400, 500, 400, 300, 200, 400 })
                   .SetSound(null)
                   .SetChannelId(NOTIFICATION_CHANNEL_ID)
                   .SetPriority(NotificationCompat.PriorityDefault)
                   .SetAutoCancel(false)
                   .SetContentTitle("Mobile")
                   .SetContentText("My service started")
                   .SetOngoing(true);
            NotificationManagerCompat notificationManager = NotificationManagerCompat.From(this);
            StartForeground(NOTIFICATION_SERVICE_ID, builder.Build());
        }
        //every 5 seconds push a notificaition
        private void DispatchNotificationThatAlarmIsGenerated(string message)
        {
            var intent = new Intent(this, typeof(MainActivity));
            intent.AddFlags(ActivityFlags.ClearTop);
            var pendingIntent = PendingIntent.GetActivity(this, 0, intent, PendingIntentFlags.OneShot);
            Notification.Builder notificationBuilder = new Notification.Builder(this, NOTIFICATION_CHANNEL_ID)
                .SetSmallIcon(Resource.Drawable.Icon)
                .SetContentTitle("Alarm")
                .SetContentText(message)
                .SetAutoCancel(true)
                .SetContentIntent(pendingIntent);
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.Notify(NOTIFICATION_AlARM_ID, notificationBuilder.Build());
        }
    }
