    public partial class MainWindow: Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            Items.Add(new MyItem());
            Items.Add(new MyItem());
            Items.Add(new MyItem());
            Items.Add(new MyItem());
            Loaded += async (s, e) =>
            {
                while (true)
                {
                    await Task.Delay(1000);
                    Items.Add(new MyItem() { Text = "new" });
                }
            };
        }
        public BindingList<MyItem> Items { get; } = new BindingList<MyItem>();
    }
