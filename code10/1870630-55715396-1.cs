    public partial class MainWindow : Window
    {
        private string optional = "Test";
        string possiblyNull = null;
        public MainWindow()
        {
            InitializeComponent();
           // here you can check null 
            myFunction(true, possiblyNull ?? optional);
           // Or 
            myFunction(true);
              
        }
        public  void myFunction(bool required, string optional = "This is optional")
        {
           MessageBox.Show(optional);
        }
    }
