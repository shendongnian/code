    public class MyDataContext :  INotifyPropertyChanged // <= doesn't work if this is missing
    {
        private ObservableCollection<Notification> notifications = new ObservableCollection<Notification>();
        public ObservableCollection<Notification> Notifications => notifications;
        public bool HasNotifications=> Notifications.Count > 0;
        public void AddNotification(Notification notificationToAdd)
        {
            notifications.Add(notificationToAdd);
            NotifyPropertyChanged(nameof(Notifications));
            NotifyPropertyChanged(nameof(HasNotifications));
        }
        
        private ICommand _AddNotification;
        public ICommand AddNotificationCMD => _AddNotification ?? (_AddNotification = new RelayCommand<object>(a => AddNotificationCommand(a)));
        private void AddNotificationCommand(object item)
        {
            AddNotification(new Notification());
        }
        
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void NotifyPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
---
    <Window x:Class="WpfApp_3_5_framework_test.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
        xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006"
        xmlns:local="clr-namespace:WpfApp_3_5_framework_test"
        mc:Ignorable="d"
        Title="MainWindow" Height="450" Width="800">
    <Grid>
        <local:UserControl1/>
        <Button Content="Add Notification" Command="{Binding AddNotificationCMD}" Height="20" Width="200" />
    </Grid>
    </Window>
