    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            listBoxWithMeaninglessNumbers.DataContext = DataStub.TestDataItems;
        }
    }
