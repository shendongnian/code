    public partial class MainWindow : Window
    {
        public ObservableCollection<string> searchItems= new ObservableCollection<string>();
    
        public MainWindow()
        {
            InitializeComponent();
        }
    
        // DEFINE A PROPERTY..
        public ObservableCollection<string> SearchItems
        {
           get {return searchItems;}
        }
    
        private void AddSearchTerm_Click(object sender, RoutedEventArgs e)
        {
            _searchTerms.Add(textBoxSearchTerm.Text);
        }
    }
