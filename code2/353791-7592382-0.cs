     /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window, INotifyPropertyChanged
        {
            private List<MyObject> _myObjects;
            public List<MyObject> MyObjects
            {
                get { return _myObjects; }
                set 
                {
                    _myObjects = value;
                    if(PropertyChanged != null)
                    {
                        PropertyChanged(this, new PropertyChangedEventArgs("MyObjects"));
                    }
                }
            }
        public MainWindow()
        {
            MyObjects = new List<MyObject>();
            // Add 20 records for sample data
            for (int i = 0; i < 20; i++)
            {
                MyObject o = new MyObject();
                o.Label = string.Format("Key{0}", i);
                o.MyValue = string.Format("Value{0}", i);    
                MyObjects.Add(o);
            }
            InitializeComponent();
            DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
    }
