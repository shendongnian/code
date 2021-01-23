    public partial class LogOn : PhoneApplicationPage
    {
        public LogOn()
        {
            InitializeComponent();
            this.DataContext = new LogOnViewModel();
            Messenger.Default.Register<LoginCompletedMessage>(
                                this,
                                msg=> NavigationService.Navigate(
                                        new Uri("/_2HandApp;component/Views/Main.xaml",
                                        UriKind.Relative) );
        }
      ....
    }
