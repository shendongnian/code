    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows;
    using System.Windows.Threading;
    namespace Services.MessageBox
    {
        public class MessageBoxService : IMessageBoxService
        {
            Dispatcher dispatcher;
            private Window mainWindow;
            public MessageBoxService()
            {
                dispatcher = Application.Current.Dispatcher;
                mainWindow = Application.Current.MainWindow;
            }
            private void UIThread(Action execute)
            {
                dispatcher.Invoke(execute);
            }
            public void Show(string caption, string message)
            {
                UIThread(() =>
                {
                    System.Windows.MessageBox.Show(mainWindow, message, caption, System.Windows.MessageBoxButton.OK);
                });
            }
            public bool? ShowDialog(string caption, string message)
            {
                bool? result = null;
                UIThread(() =>
                {
                    result = new Windows.Modal(message, caption).ShowDialog(mainWindow);
                });
                return result;
            }
        }
    }
