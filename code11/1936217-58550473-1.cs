    public class MyClass {
        public List<NotificationsClass> Notifications;
 
        public MyClass(List<NotificationClass> passedList)
        {
            Notifications = notificationsGENERATEDList;
            Notifications.Add(passedList);
        }
    }
