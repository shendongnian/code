    using System.Windows;
    namespace TestNotificationQueue
    {
        /// <summary>
        /// Interaction logic for NotificationWindow.xaml
        /// </summary>
        public partial class NotificationWindow : Window
        {
            public NotificationWindow(NotificationInfo notificationInfo)
            {
                InitializeComponent();
                TextBoxMessage.Text = notificationInfo.Message;
            }
        }
    }
