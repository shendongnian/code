    public partial class UserControl1 : UserControl
    {
        public static readonly RoutedEvent UserControlLostFocusEvent =
            EventManager.RegisterRoutedEvent("UserControlLostFocus",
                                             RoutingStrategy.Bubble,
                                             typeof(RoutedEventHandler),
                                             typeof(UserControl1));
        public event RoutedEventHandler UserControlLostFocus
        {
            add { AddHandler(UserControlLostFocusEvent, value); }
            remove { RemoveHandler(UserControlLostFocusEvent, value); }
        }
        public UserControl1()
        {
            InitializeComponent();
            this.IsKeyboardFocusWithinChanged += UserControl1_IsKeyboardFocusWithinChanged;
        }
        void UserControl1_IsKeyboardFocusWithinChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.OldValue == true && (bool)e.NewValue == false)
            {
                RaiseEvent(new RoutedEventArgs(UserControl1.UserControlLostFocusEvent, this));
            }
        }
    }
