    public class NotificationEventArgs : EventArgs
    {
        public NotificationEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; }
    }
