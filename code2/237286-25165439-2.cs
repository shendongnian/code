    using System.Threading;
    using WPFServiceHost1.Service;
    
    namespace WPFServiceHost1
    {
        /// <summary>
        /// Interaction logic for Window1.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public SynchronizationContext _SyncContext = SynchronizationContext.Current;
            private ClientServiceHost _ClientServiceHost;
    
            public MainWindow()
            {
                InitializeComponent();
                _ClientServiceHost = new ClientServiceHost(this);
            }
    
            private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                _ClientServiceHost.Dispose();
            }
        }
    }
