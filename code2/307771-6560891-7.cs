    using System.Windows;
    using WpfTreeViewBinding.ViewModels;
    
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
    
                itemView.DataContext = new ItemViewModel();
            }
        }
    }
