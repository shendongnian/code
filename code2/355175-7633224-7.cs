    namespace WpfApplication2
    {
        public partial class Window2 : Window
        {
            public Window2()
            {
                InitializeComponent();
            }
    
            private void Window_StateChanged(object sender, EventArgs e)
            {
                if (((Window)sender).WindowState == WindowState.Maximized)
                    ((Window)sender).WindowState = WindowState.Normal;
            }
    
            private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
            {
                try
                {
                    DragMove();
                }
                catch ()
                {}
            }
    
    }
        }
