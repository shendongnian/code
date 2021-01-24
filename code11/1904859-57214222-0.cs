    [Obsolete]
    public override void FailedToRegisterForRemoteNotifications(UIApplication application, NSError error)
    {
        new UIAlertView("Error registering push notifications", error.LocalizedDescription, null, "OK", null).Show();
    }
