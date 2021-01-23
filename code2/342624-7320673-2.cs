    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
    
            // Create dummy test data.
            // Normally this will be passed to the window or set externally
            var container = new Container();
            container.Problems.Add(new Problem {Name = "Foo"});
            container.Problems.Add(new Problem {Name = "Bar"});
            container.Problems.Add(new Problem {Name = "hello"});
            container.Problems.Add(new Problem {Name = "world"});
    
            DataContext = container;
        }
    }
