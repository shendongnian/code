    [Flags]
    public enum NotificationMethodType {
        None = 0,
        Email = 1,
        Fax = 2,
        Sms = 4,
        All = Email | Fax | Sms
    }
