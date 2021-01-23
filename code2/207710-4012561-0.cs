    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private Array array1 = new[] { "test1", "test2", "test3" };
        public Array Array1 { get { return array1; } }
        public string string1 = "string";
        public string String1
        {
            get { return string1; }
            set
            {
                string1 = value;
                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("String1"));
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            String1 = DateTime.Now.ToString();
            array1.SetValue("another test", 0); 
            PropertyChanged(this, new PropertyChangedEventArgs("Array1"));
        }
    }
