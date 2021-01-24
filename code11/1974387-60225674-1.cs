    using System;
    using System.Collections.Generic;
    using System.Windows;
    namespace TestNotificationQueue
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            private Queue<NotificationInfo> _notificationQueue = new Queue<NotificationInfo>();
            private NotificationWindow _currentNotificationWindow;
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                ShowOrQueueNotification(new NotificationInfo(TextBoxMessage.Text));
            }
            private void ShowOrQueueNotification(NotificationInfo notificationInfo)
            {
                // If not notification is presented, create one.
                if (_currentNotificationWindow == null)
                {
                    _currentNotificationWindow = new NotificationWindow(notificationInfo);
                    _currentNotificationWindow.Closed += CurrentNotificationWindow_Closed;
                    _currentNotificationWindow.Show();
                }
                else
                    _notificationQueue.Enqueue(notificationInfo);
            }
            private void CurrentNotificationWindow_Closed(object sender, EventArgs e)
            {
                // this is one of the most important line, you need to set the current to null, else all new notification will be queued.
                _currentNotificationWindow = null;
                if(_notificationQueue.Count > 0)
                    ShowOrQueueNotification(_notificationQueue.Dequeue());
            }
        }
    }
