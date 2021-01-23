    public partial class MainWindow : Window
    {
        public Dictionary<string, string> MyHashTable
        {
            get;
            set;
        }
        public MainWindow()
        {
            InitializeComponent();
            MyHashTable = new Dictionary<string, string>();
            MyHashTable.Add("Key 1", "Value 1");
            MyHashTable.Add("Key 2", "Value 2");
            MyHashTable.Add("Key 3", "Value 3");
            MyHashTable.Add("Key 4", "Value 4");
            this.DataContext = this;
        }
    }
