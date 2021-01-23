     public partial class MainWindow : Window
    {
        private Array array1 = new[] {"test1", "test2", "test3"};
        public Array Array1 { get { return array1; } }
        public string string1 = "string";
        public string String1 { get { return string1; } }
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
        }
    }
