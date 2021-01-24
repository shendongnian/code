    Messenger.Default.Register<NotificationMessage>(this, GetMessage);
    private void GetMessage(NotificationMessage obj)
            {
                MessageBox.Show(obj.Notification);
            }
