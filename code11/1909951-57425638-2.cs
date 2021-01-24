    [BroadcastReceiver]
    class NotivicationBroadCast : BroadcastReceiver
    {
        public override void OnReceive(Context context, Intent intent)
        {
            string action = intent.Action;
            if (action.Equals("notification_dismiss"))
            {
                 NotificationManager notificationManager = (NotificationManager)context.GetSystemService(Context.NotificationService);            
                 notificationManager.Cancel(notificationId);
            }
            if (action.Equals("notification_cancel"))
            {              
                cancellationToken.Cancel();
            }
        }
    }
