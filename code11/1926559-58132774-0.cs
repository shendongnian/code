    void CreateNotificationChannel()
            {
                if (Build.VERSION.SdkInt < BuildVersionCodes.O)
                {
                    return;
                }
            var channel = new NotificationChannel(CHANNEL_ID, Resources.GetString(Resource.String.app_name), NotificationImportance.Default)
            {
                Description = ""
            };
            var notificationManager = (NotificationManager)GetSystemService(NotificationService);
            notificationManager.CreateNotificationChannel(channel);
        }
