    private NotificationViewModel _notificationtMessage = new NotificationViewModel();
    public NotificationViewModel NotificationMessage
    {
        get
        {
            return _notificationtMessage;
        }
        set
        {
            _notificationtMessage = value;
            NotifyOfPropertyChange(() => NotificationMessage);
            NotifyOfPropertyChange(() => IsNotificationVisible);
        }
    }
    public bool IsNotificationVisible
    {
        get
        {
            return Database.GetNotification().Title.Length != 0;
        }
    }
