    public partial class MainWindow : Window
    {
        private string optional = "Test";
        string possiblyNull = null;
        public MainWindow()
        {
            InitializeComponent();
            myFunction(true, possiblyNull ?? optional);
        }
        public  void myFunction(bool required, string optional = "This is optional")
        {
           MessageBox.Show(optional);
        }
    }
