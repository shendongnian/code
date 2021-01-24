     public partial class UserControl1 : UserControl
        {
            public Action<UserControl1> CloseAction { get; set; }
            public UserControl1()
            {
                InitializeComponent();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                CloseAction(this);
            }
        }
    
