    public partial class InstrumentFinderWindow: UserControl, IInteractionRequestAware
    {
        public CustomPopupView()
        {
            InitializeComponent();
        }
        private void Close_Click(object sender, RoutedEventArgs e)
        {
            FinishInteraction?.Invoke();
        }
        public Action FinishInteraction { get; set; }
        public INotification Notification { get; set; }
    }
