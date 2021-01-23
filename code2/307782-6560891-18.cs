    using System.Windows;
    
    namespace WpfTreeViewBinding
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
    
                var itemProvider = new ItemProvider();
    
                var items = itemProvider.GetItems("C:\\Temp");
    
                DataContext = items;
            }
        }
    }
