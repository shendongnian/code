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
    // ----->   If no notification is presented, create one.
                if (_currentNotificationWindow == null)
                {
                    _currentNotificationWindow = new NotificationWindow(notificationInfo);
                    _currentNotificationWindow.Closed += CurrentNotificationWindow_Closed;
                    _currentNotificationWindow.Show();
                }
                else
    // ----->       queue it.
                    _notificationQueue.Enqueue(notificationInfo);
            }
            private void CurrentNotificationWindow_Closed(object sender, EventArgs e)
            {
    // ----->   This is crucial, you need to set the current to null, else all new notification will be queued and never be presented.
                _currentNotificationWindow = null;
                if(_notificationQueue.Count > 0)
                    ShowOrQueueNotification(_notificationQueue.Dequeue());
            }
        }
    }
