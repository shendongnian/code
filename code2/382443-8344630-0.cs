    public partial class MainWindow : Window
    {
        public ObservableCollection<string> MyCollection { get; set; }
    
        public MainWindow()
        {
            InitializeComponent();
            MyCollection = new ObservableCollection<string>();
    
            Random random = new Random();
            DispatcherTimer aTimer = new DispatcherTimer();
            aTimer.Tick += (sender, e) =>
            {
                MyCollection.Add(random.Next(0, 100).ToString());
            };
            aTimer.Interval = new TimeSpan(0,0,0,0,500);
            aTimer.Start();
    
            Binding myBinding2 = new Binding();
            myBinding2.Source = this;
            myBinding2.Path = new PropertyPath("MyCollection");
            ListBoxx.SetBinding(ListBox.ItemsSourceProperty, myBinding2);
        }
    }
