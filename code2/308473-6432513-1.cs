    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ITest test = new TestClass();
            this.DataContext = test;
        }
    }
    interface ITest
    {
        ObservableCollection<KeyValuePair<DateTime, DateTime>> Jours { get; set; }
    }
    class TestClass : ITest
    {
        public TestClass()
        {
            Jours = new ObservableCollection<KeyValuePair<DateTime, DateTime>>();
            Jours.Add(new KeyValuePair<DateTime, DateTime>(DateTime.Now, DateTime.Now));
            Jours.Add(new KeyValuePair<DateTime, DateTime>(DateTime.Now, DateTime.Now));
            Jours.Add(new KeyValuePair<DateTime, DateTime>(DateTime.Now, DateTime.Now));
        }
        public ObservableCollection<KeyValuePair<DateTime, DateTime>> Jours { get; set; }
    }
