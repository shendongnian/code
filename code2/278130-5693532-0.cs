    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            this.DataContext = new MainWindowViewModel();
        }
    }
    
    public class MainWindowViewModel
    {
        public MainWindowViewModel()
        {
            myData = new List<Item>
            {
                new Item{ Id=5, Description="Brown Car", Title="my car"},
                new Item{Id=1,Description="sweet dog", Title="my dog"},
    
            };
        }
    
        public List<Item> MyData
        {
            get
            {
                return myData;
            }
    
        }
        List<Item> myData;
    }
