    public static void CheckAndAskPushNotificationPermission()
    {
        if (UIDevice.CurrentDevice.CheckSystemVersion(10, 0))
        { UNUserNotificationCenter.Current.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Badge | UNAuthorizationOptions.Sound,
                                                                (granted, error) =>
        {
            if (granted)
                InvokeOnMainThread(UIApplication.SharedApplication.RegisterForRemoteNotifications);
        });
    } else if (UIDevice.CurrentDevice.CheckSystemVersion (8, 0)) {
        var pushSettings = UIUserNotificationSettings.GetSettingsForTypes (
                UIUserNotificationType.Alert | UIUserNotificationType.Badge | UIUserNotificationType.Sound,
                new NSSet ());
        UIApplication.SharedApplication.RegisterUserNotificationSettings (pushSettings);
        UIApplication.SharedApplication.RegisterForRemoteNotifications ();
    } else {
        UIRemoteNotificationType notificationTypes = UIRemoteNotificationType.Alert | UIRemoteNotificationType.Badge | UIRemoteNotificationType.Sound;
        UIApplication.SharedApplication.RegisterForRemoteNotificationTypes (notificationTypes);
    }
    }
