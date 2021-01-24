    using System.Windows;
    namespace WpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
            private void MenuItem_Click(object sender, RoutedEventArgs e)
            {
                VM thisDC = (VM)this.DataContext;
                if (thisDC.Connected)
                {
                    // DisConnect
                    thisDC.Connected = false;
                }
                else
                {
                    ConnectWindow cw = new ConnectWindow
                    {
                        Owner = this,
                        DataContext = this.DataContext
                    };
                    cw.ShowDialog();
                }
            }
        }
    }
