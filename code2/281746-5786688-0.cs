      public partial class MainWindow : Window
    {
        private ObservableCollection<Directory> directoryList;
        public MainWindow()
        {
            InitializeComponent();
            directoryList = new ObservableCollection<Directory>();
            Directory _dirtemp = new Directory();
            _dirtemp.IKey = "1";
            _dirtemp.IValue = "Steve";
            directoryList.Add(_dirtemp);
            _dirtemp = new Directory();
            _dirtemp.IKey = "2";
            _dirtemp.IValue = "John";
            directoryList.Add(_dirtemp);
            this.comboBox1.DataContext = DirectoryList;
            //OR for the entire window you can simply do this.DataContext = DirectoryList;
        }
        public ObservableCollection<Directory> DirectoryList
        {
            get { return directoryList; }
        } 
    }
    public class Directory
    {
        private string _ikey;
        public string IKey
        {
            get
            {
                return _ikey;
            }
            set
            {
                _ikey = value;
            }
        }
        private string _ivalue;
        public string IValue
        {
            get
            {
                return _ivalue;
            }
            set
            {
                _ivalue = value;
            }
        }
    }
