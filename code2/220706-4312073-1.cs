    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            MyClasses = new ObservableCollection<MyClass>();
            MyClasses.Add(new MyClass("My String 1"));
            MyClasses.Add(new MyClass("My String 2"));
            MyClasses.Add(new MyClass("My String 3"));
            this.DataContext = this;
        }
        public ObservableCollection<MyClass> MyClasses
        {
            get;
            private set;
        }
    }
