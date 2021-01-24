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
    }
