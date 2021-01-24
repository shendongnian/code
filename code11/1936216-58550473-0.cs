    public class MyClass {
        public List<NotificationsClass> _notifications;
 
        public MyClass()
        {
            _notifications = notificationsGENERATEDList;
        }
        public Notifications
        {
            get { return _notifications; }
            set { _notifications.AddRange(value); }
        }
    }
