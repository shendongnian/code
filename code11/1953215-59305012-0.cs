...
using UserNotifications;
...
 public override bool FinishedLaunching(UIApplication application, NSDictionary launchOptions)
   {
       ....
        //after iOS 10
        if(UIDevice.CurrentDevice.CheckSystemVersion(10,0))
        {
            UNUserNotificationCenter center = UNUserNotificationCenter.Current;
            center.RequestAuthorization(UNAuthorizationOptions.Alert | UNAuthorizationOptions.Sound | UNAuthorizationOptions.UNAuthorizationOptions.Badge, (bool arg1, NSError arg2) =>
                 {
                 });
            center.Delegate = new NotificationDelegate();
        }
        else if(UIDevice.CurrentDevice.CheckSystemVersion(8, 0))
        {
            var settings = UIUserNotificationSettings.GetSettingsForTypes(UIUserNotificationType.Alert| UIUserNotificationType.Badge| UIUserNotificationType.Sound,new NSSet());
            UIApplication.SharedApplication.RegisterUserNotificationSettings(settings);
        }
        return true;
    }
New to iOS 10, an app can handle Notifications differently when it is in the foreground and a Notification is triggered. By providing aUNUserNotificationCenterDelegate and implementing theUserNotificationCentermethod, the app can take over responsibility for displaying the Notification. For example:
using System;
using ObjCRuntime;
using UserNotifications;
namespace xxx
{
 public class NotificationDelegate:UNUserNotificationCenterDelegate
   {
    public NotificationDelegate()
    {
    }
    public override void WillPresentNotification(UNUserNotificationCenter center, UNNotification notification, Action<UNNotificationPresentationOptions> completionHandler)
    {
        // Do something with the notification
        Console.WriteLine("Active Notification: {0}", notification);
        // Tell system to display the notification anyway or use
        // `None` to say we have handled the display locally.
        completionHandler(UNNotificationPresentationOptions.Alert|UNNotificationPresentationOptions.Sound);
    }
    public override void DidReceiveNotificationResponse(UNUserNotificationCenter center, UNNotificationResponse response, Action completionHandler)
    {
        // Take action based on Action ID
        switch (response.ActionIdentifier)
        {
            case "reply":
                // Do something
                break;
            default:
                // Take action based on identifier
                if (response.IsDefaultAction)
                {
                    // Handle default action...
                }
                else if (response.IsDismissAction)
                {
                    // Handle dismiss action
                }
                break;
        }
        // Inform caller it has been handled
        completionHandler();
    }
  }
}
