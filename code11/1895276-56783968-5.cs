    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Test> BitsList { get; set; }
        public MainPage()
        {
            this.InitializeComponent();
            BitsList = new ObservableCollection<Test>();
            for (int i = 0; i < 10; i++)
            {
                Random random = new Random();
                BitsList.Add(new Test() { content = random.Next(0, 9) });
            }
        }
    }
