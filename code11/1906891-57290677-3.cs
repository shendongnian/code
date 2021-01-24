    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            Models = new List<Model>
            {
                new Model(1,"hello"),
                new Model(1,"foo"),
                new Model(88,"hello"),
                new Model(2,"world"),
            };
            DataContext = this;
            InitializeComponent();
        }
        public List<Model> Models { get; set; }
    }
