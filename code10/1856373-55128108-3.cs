    using System.Windows;
    namespace WpfApp1
    {
        public partial class ConnectWindow : Window
        {
            public ConnectWindow()
            {
                InitializeComponent();
            }
            private bool verified = true;
            private void Button_Click(object sender, RoutedEventArgs e)
            {
                if (verified)
                {
                    VM thisDC = (VM)this.DataContext;
                    thisDC.Connected = true;
                    this.Close();
                }
                else
                {
                    // error message
                    this.Close();
                }
            }
        }
    }
 
