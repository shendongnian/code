    public class SomeClass
    {
        private OnNotificationEventHandler _notificationEventHandler;
        public event OnNotificationEventHandler OnNotification
        {
            add { _notificationEventHandler += value; }
            remove { _notificationEventHandler -= value; }
        }
        protected void RaiseNotificationEvent(NotificationEventArgs args)
        {
            _notificationEventHandler?.Invoke(this, args);
        }
        public void SomeMethod()
        {
            //Your class does something that requires consumer notification
            var args = new NotificationEventArgs("Something happened!");
            //Raise the event for the consumers who are listening (if any)
            RaiseNotificationEvent(args);
        }
    }
