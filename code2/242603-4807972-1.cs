    namespace Contact_Interests
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
             public MainWindow()
             {
                  InitializeComponent();
                  this.DataContext = new MainWindowViewModel();
             }
         }
     }
