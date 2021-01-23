    public partial class MessageboxNew : Window
        {
            public MessageboxNew()
            {
                InitializeComponent();
            }
    
            private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
            {
                DialogResult = true;
            }
    
            private void cancel_Click(object sender, RoutedEventArgs e)
            {
                DialogResult = false;
            }
    
            private void FrameworkElement_OnLoaded(object sender, RoutedEventArgs e)
            {
                this.MouseDown += delegate { DragMove(); };
            }
        }
