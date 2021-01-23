    public partial class SomeWindow : Window
    {
        Subscription _subscription = new Subscription();
        public SomeWindow()
        {
            InitializeComponent();
            _subscription.Subscribe(Messages.REQUEST_DEPLOYMENT_SETTINGS_CLOSED, obj =>
                {
                    this.Close();
                });
        }
    }
