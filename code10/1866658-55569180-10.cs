    using System.Windows;
    
    namespace zzWpfApp1
    {
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                DataContext = new MainWindowViewModel();
            }
        }
    }
   
