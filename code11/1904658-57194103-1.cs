        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                SecurityViewModel vm = new SecurityViewModel();
                DataContext = vm;
            }
            private void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
            {
                if (this.DataContext != null)
                {
                    ((dynamic)this.DataContext).AddTempPassword =
                    ((PasswordBox)sender).Password;
                }
            }
        }
    }
