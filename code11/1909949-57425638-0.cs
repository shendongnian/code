    public void Push()
    {
        ...
        Intent intentDismiss = new Intent(this, typeof(NotivicationBroadCast));
        intentDismiss.SetAction("notification_dismiss");
        PendingIntent pendingIntentDismiss = PendingIntent.GetBroadcast(this, 0,
        intentDismiss, PendingIntentFlags.UpdateCurrent);
    
        Intent intentCancel = new Intent(this, typeof(NotivicationBroadCast));
        intentCancel.SetAction("notification_cancel");
        PendingIntent pendingIntentCancel = PendingIntent.GetBroadcast(this, 0,
        intentCancel, PendingIntentFlags.UpdateCurrent);
        var builder = new NotificationCompat.Builder(Activity, ChannelId)
                      .SetAutoCancel(true)
                      .SetContentTitle(Title)
                      .SetSmallIcon(Resource.Drawable.stop_bus)
                      .SetContentText(Text)
                      .AddAction(0, "Dont Dismiss", pendingIntentDismiss)
                      .AddAction(0, "Dismiss", pendingIntentCancel );
        var notificationManager = NotificationManagerCompat.From(Activity);
        notificationManager.Notify(41144, builder.Build());
    }
