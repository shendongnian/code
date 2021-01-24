    public partial class MainWindow : Window
    {
        public class Item
        {
            public string Received { get; set; }
            public string Sent { get; set; }
        }
        public List<Item> Items { get; }
        public MainWindow()
        {
            InitializeComponent();
            Items = new List<Item>
            {
                new Item { Received = "1111 111 11 111 11 1" },
                new Item { Received = "2222 2 22 2  2 222222222 2 222222 22222222 222222222222 2" },
                new Item { Sent = "333333333 3333333 333   33333 3  3 33 333333333 3333" },
                new Item { Received = "444444444444444 444 44444444444444 44  4 44444444444444444 4 4 4444444444 4 444   444444444444" },
            };
            DataContext = this;
        }
    }
