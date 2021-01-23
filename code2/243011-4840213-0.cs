    // within some Android.Content.Context subclass (Activity, Service, etc.)
    void ShowNotification ()
    {
        IEnumerable<char> text = GetText (Resource.String.local_service_started);
        var notification = new Notification (Resource.Drawable.stat_sample, 
                text, 
                System.Environment.TickCount);
        PendingIntent contentIntent = PendingIntent.GetActivity (this, 0, 
                new Intent (this, typeof (LocalServiceActivities.Controller)), 
                0);
        notification.SetLatestEventInfo (this, 
                GetText (Resource.@string.local_service_label), 
                text, 
                contentIntent);
        var nm = (NotificationManager) GetSystemService (NotificationService);
        nm.Notify (Resource.String.local_service_started, notification);
    }
