    public partial class MyControl : UserControl
    {
        public MyControl()
        {
            InitializeComponent();
        }
        #region Routed Events
        public static readonly RoutedEvent ControlClosedEvent = EventManager.RegisterRoutedEvent(
            "ControlClosed",
            RoutingStrategy.Bubble,
            typeof(RoutedEventHandler),
            typeof(MyControl));
        public event RoutedEventHandler ControlClosed
        {
            add { AddHandler(ControlClosedEvent, value); }
            remove { RemoveHandler(ControlClosedEvent, value); }
        }
        #endregion Routed Events
        private void Close(object sender, RoutedEventArgs e)
        {
            var rea = new RoutedEventArgs(ControlClosedEvent);
            RaiseEvent(rea);
        }
    }
