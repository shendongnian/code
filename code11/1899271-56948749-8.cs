    public partial class MainWindow : Window
    {
        public static readonly DependencyProperty NotifyIconProperty = DependencyProperty.Register(
          "NotifyIcon",
          typeof(TaskbarIcon),
          typeof(Window),
          new PropertyMetadata(default(TaskbarIcon)));
        public TaskbarIcon NotifyIcon { get { return (TaskbarIcon) GetValue(MainWindow.NotifyIconProperty); } set { SetValue(MainWindow.NotifyIconProperty, value); } }
        public MainWindow(TaskbarIcon taskbarIcon, INotifyIconViewModel dataContext)
        {
            this.notifyIcon = taskbarIcon;     
            this.DataContext = dataContext; 
        }
    }
